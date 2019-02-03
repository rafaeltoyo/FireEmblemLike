var router = require('./router');

var people = [
    {id: 1, name: "Foobar", gender: "M"},
    {id: 2, name: "Barfoo", gender: "F"}
]

var app = router(3412);

app.interceptor((req, res, next) => {
    console.log('Receiving request ...');
    res.writeHead(200, {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET,POST,OPTIONS,DELETE,PUT',
        'Access-Control-Allow-Header': 'Content-Type',
        'Content-Type': 'application/json;charset=UTF-8'
    });
    next();
});

app.get('/people', function (req, res) {
    res.write(JSON.stringify(people));
    res.end();
});

app.put('/people', function (req, res) {
    let person = JSON.parse(req.body);

    if (person != null && person.name != null && ['M', 'F'].indexOf(person.gender) >= 0) {
        person.id = people.length + 1;
        people.push(person);
        res.write(JSON.stringify({'result': true}));
    }
    else {
        res.write(JSON.stringify({'result': false}));
    }

    res.end();
});

app.post('/people', function (req, res) {
    let new_person = JSON.parse(req.body);

    let person = people.some((e) => { e.id == person.id });
    if (person != null) {
        person.name = new_person.name;
        person.gender = new_person.gender;
    }
    else {
        console.log("Element ["  + new_person.id + "] not found!");
    }

    res.end();
});