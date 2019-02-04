
var createApi = function (url) {

    let api = {};

    let routes = {};

    const methods = ['GET', 'PUT', 'POST', 'DELETE', 'OPTIONS'];

    const createFnRequest = (full_url, method, content, callback) => {
        let xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4) {
                let responseText = '';
                try {
                    responseText = JSON.parse(this.responseText)
                }
                catch (error) {
                    console.log(error);
                }
                response = {
                    'code': this.status,
                    'content': responseText
                };
                if (this.status == 200) {
                    if (callback != null) callback(response);
                }
            }
            
        };
        xhttp.open(method.toUpperCase(), full_url, true);
        xhttp.send(content);
    };

    const createMethods = (endpoint) => {
        api[endpoint] = {};
        methods.forEach(method => {
            api[endpoint][method.toLowerCase()] = (p1, p2) => {
                let content = null;
                let callback = null;
                if (p1 != null && p1 instanceof Function) {
                    callback = p1;
                }
                else {
                    content = p1;
                    callback = p2;
                }
                createFnRequest(url + endpoint, method, content, callback);
            };
            return true;
        });
    };

    api.register = (endpoint) => {
        createMethods(endpoint);
    };

    return api;
}

// Initializing API
let api = createApi("http://localhost:3412/");
api.register('people');

new_person = JSON.stringify({'name': 'Bleeee', 'gender': 'M'});
api.people.put(new_person, rs => {
    if (rs.content.result) {
        console.log("PUT successful!");
    }
    else {
        console.log("PUT failed ...")
    }

});

// GET people from API
api.people.get(rs => {
    let root = document.getElementById('responseDisplay');
    rs.content.forEach(person => {
        let item = document.createElement('div');
        item.appendChild(document.createTextNode(person.name));
        item.appendChild(document.createTextNode(person.gender));
        root.appendChild(item);
    });
    console.log(rs);
});
