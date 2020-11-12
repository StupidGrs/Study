/**
 * Created by webber-ling on 13/10/2020.
 */


// import { browser, element, by } from "protractor";
let Request = require("request");


xdescribe("Sample - Chercher.tech",function(){

    it("Get id=90",function(done){

        Request.get({
            "headers": { "content-type": "application/json" },
            "url": "https://chercher.tech/sample/api/product/read?id=90",
            rejectUnauthorized: false,
        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Body : ******");
            console.dir(JSON.parse(body));

            console.dir("Response Code ****:"+response.statusCode);

            expect(response.statusCode).toBe(200);
            done();
        });

    });

});


describe("Sample - SRC",function(){


    it("Get public articles",function(done){

        Request.get({
            rejectUnauthorized: false,

            "headers": { "apikey": "xBnWRZClTXf0YpMlOLQz0UQjPzZplPLA" },
            "url": "https://api.src.us-east-1.dev.int.mercer.com/v1/api/articles/public/recent",

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);

            console.dir(" --------------- Start Body ------------------");
            // console.dir(JSON.parse(body));
            let contents = JSON.parse(body);
            console.log('Total articles returned: ' + contents.length);

            for(let i=0;i<contents.length;i++){
                console.dir("Article " + i +" : ---------------------------------");
                // console.log(contents[i]);
                console.log(contents[i].date);
            }

            console.dir(" --------------- End Body ------------------");

            done();
        });

    });


});




const apiResource = require("protractor-api-resource").ProtractorApiResource;

xdescribe("Test response for all REST API methods", function () {

    var apiClient, serviceEnpoints = {
        getPosts: {
            path: "/posts/:postId:"
        },
        createPost: {
            path: "/posts",
            method: "POST"
        },
        updatePost: {
            path: "/posts/:postId:",
            method: "PUT"
        },
        patchPost: {
            path: "/posts/:postId:",
            method: "PATCH"
        },
    };


    beforeAll(function () {
        apiClient = new apiResource("https://jsonplaceholder.typicode.com/");
        apiClient.registerService(serviceEnpoints);
    });


    it("Test GET method", function (done) {
        var expectedResponse = {
            "userId": 1,
            "id": 1,
            "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
            "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
        };

        apiClient.getPosts({postId: 1}).toJSON().then(function (actualResponse) {
            expect(actualResponse).toEqual(expectedResponse);
            done();
        });
    });
});