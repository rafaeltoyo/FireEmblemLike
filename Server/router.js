var http = require('http');

/**
 * 
 * @param {number} port
 */
const createRouter = function (port) {

    var api = {};

    /**************************************************************************/

    var routes = {};

    const methods = ['GET', 'PUT', 'POST', 'DELETE', 'OPTIONS'];

    methods.forEach(function (method) {
        routes[method] = {};
        api[method.toLowerCase()] = function (path, fn) {
            routes[method][path] = fn;
        };
    });

    /**************************************************************************/

    var interceptors = [];

    api.interceptor = function (interceptor) {
        interceptors.push(interceptor);
    }

    const executeInterceptors = function (number, req, res) {
        var interceptor = interceptors[number];
        if (!interceptor) return;
        interceptor(req, res, function () {
            executeInterceptors(++number, req, res);
        });
    }

    /**************************************************************************/

    const handleBody = function (req, res, next) {
        var body = [];
        req.on('data', function (chunk) {
            body.push(chunk);
        });
        req.on('end', function () {
            req.body = Buffer.concat(body).toString();
            next();
        });
    }

    /**************************************************************************/

    http.createServer(function (req, res) {
        handleBody(req, res, function () {

            executeInterceptors(0, req, res);

            if (!routes[req.method][req.url]) {
                res.statusCode = 404;
                return res.end();
            }

            res.statusCode = 200;
            routes[req.method][req.url](req, res);
        });
    }).listen(port);

    /**************************************************************************/

    return api;
};

module.exports = createRouter;