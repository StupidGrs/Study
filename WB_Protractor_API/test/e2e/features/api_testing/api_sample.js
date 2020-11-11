/**
 * Created by webber-ling on 13/10/2020.
 */

"use strict";

// import { browser, element, by } from "protractor";
let Request = require("request");
let api_func = require('./api_func');
let fapi_func = new api_func();

/////https://chercher.tech/protractor/api-testing-protractor#
//
// HTTP Status Codes
// Before diving into communication with other APIs, let's review the HTTP status codes we may encounter during the process. They describe the outcome of our requests and are essential for error handling.
//
// 1xx - Informational
// 2xx - Success: These status codes indicate that our request was received and processed correctly. The most common success codes are 200 OK, 201 Created and 204 No Content.
// 3xx - Redirection: This group shows that the client had to do additional action to complete the request. The most common redirection codes are 301 Moved Permanently, 304 Not Modified.
// 4xx - Client Error: This class of status codes is used when the request sent by the client was faulty in some way. The server response usually contains the explanation of the error. The most common client error codes are 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found, 409 Conflict.
// ​
// 5xx - Server Error: These codes are sent when the server failed to fulfill a valid request due to some error. The cause may be a bug in the code or some temporary or permanent incapability. The most common server error codes are 500 Internal Server Error, 503 Service Unavailable.



xdescribe("Sample - Chercher.tech",function(){


    //The GET method is used to extract information from the given server using a given URI. While using the GET request, it should only extract data and should have no other effect on the data.
    it("Get - id=90",function(done){

        Request.get({
            rejectUnauthorized: false,
            "headers": { "content-type": "application/json" },
            "url": "https://chercher.tech/sample/api/product/read?id=90",

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Body : ******");
            console.dir(JSON.parse(body));

            console.dir("Response Code ****:"+ response.statusCode);
            console.log("ID ****:"+JSON.parse(body).id);
            console.log("Name ****:"+JSON.parse(body).name);
            console.log("Description ****:"+JSON.parse(body).description);
            console.log("Price ****:"+JSON.parse(body).price);

            expect(response.statusCode).toBe(200);
            done();
        });

    });

    //put method is like an UPDATE query in SQL which inserts or updates a record depending upon whether the given record exists
    it("Put - add new entry",function(done){

        // after run the test, goto link to see the updates https://chercher.tech/sample/api-ui

        Request.put({
            rejectUnauthorized: false,
            "headers": { "content-type": "application/json" },
            "url": "https://chercher.tech/sample/api/product/create",
            "body": JSON.stringify({
                "name": "some stupid guy",
                "description": "90033"
            })
        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Body : ******");
            console.dir(response.body);

            console.log("Header ****:");
            console.log(response.headers);

            expect(response.body).toBe('Product was created with UI.');
            done();
        });

    });


    //post method is like an INSERT query in SQL, which always creates a new record in the database.
    it("Post - insert new entry",function(done){

        // after run the test, goto link to see the updates https://chercher.tech/sample/api-ui

        Request.post({
            rejectUnauthorized: false,
            "headers": { "content-type": "application/json" },
            "url": "https://chercher.tech/sample/api/product/update",
            "body": JSON.stringify({
                "id":"130",
                "name": "some stupid guy",
                "description": "90033",
                "price":"4500",
            })
        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Body : ******");
            console.dir(response.body);

            console.log("Header ****:");
            console.log(response.headers);

            // expect(response.body).toBe('Product was created with UI.');
            done();
        });

    });

});



module.exports = {
    "title": "Test_Auto_Event",
    "regions":[],
    "taxonomies": ["5c616ae4e52cc2355e1a1031"],
    "tags": "",
    "excerpt": "Test_Auto excerpt",
    "content": "<p>Test_Auto content</p>",
    "company":{"company_name":"CompAuto",
        "company_domains":"src.mercer.com",
        "size":"$5B to $10B",
        "website":"",
        "description":"",
        "twitter":"",
        "linkedIn":"",
        "facebook":"",
        "tags":"",
        "sfdc_id":"id_4568217",
        "row_id":"",
        "onecode":"",
        "global_rel_mgr_email":"",
        "global_rel_mgr_legal_name":"",
        "global_rel_mgr_emplid":"",
        "global_rel_mgr_sfdc_id":"",
        "num_of_emp_db":null,
        "current_year_revenue":null,
        "prior_year_revenue":null,
        "client_type":"",
        "addresses":{"list":[{"country":null,"state":null,"city":null,"zip_code":null,"phone":null}]},
        "location":{},
        "disclaimer":"",
        "company_status":"active",
        "followers_count":1,
        "business_role":"Mercer Consultant",
        "taxonomies":[],
        "regions":null,
        "sectors":null,
        "_id":"5d47d70a07ea03001d99760f",
        "is_featured":false,
        "last_updated_date":null,
        "disabled_users":false,
        "disabled_content":false,
        "createdAt":"2019-08-05T07:13:14.422Z",
        "updatedAt":"2019-08-06T10:00:55.614Z",
        "__v":0,
        "id":"5d47d70a07ea03001d99760f",
        "logo":null},
    "type": "Webinar",
    "start_date": "2020-09-23T06:00:00.000Z",
    "end_date": "2020-09-24T14:00:00.000Z",
    "location": "San Francisco, United States",
    "content_url": null
};


let eventName = 'Demo_Test_Auto_Event_9527';
let eventID, token;
let token_strapi = 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI1ZDliM2M2NDRkM2MxODAwMWVmNmYzNzQiLCJpYXQiOjE2MDI3Mzg5NzMsImV4cCI6MTYwNTMzMDk3M30.6AyfNT4GIVr8gd0qEhp55Gv_mRix4aVSFof_Y4-dhEM';
// let status = "pending";
let status = "approved";
// let status = "rejected";

describe("Sample - SRC",function(){





    xit("1.1 Get public articles",function(done){

        console.dir(" --------------- 1.1 Get public articles ------------------");

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

            status = response.statusCode;

            console.dir(" --------------- Start Body ------------------");
            // console.dir(JSON.parse(body));
            let contents = JSON.parse(body);
            console.log('Total articles returned: ' + contents.length);

            for(let i=0;i<contents.length;i++){
                // console.dir("Article " + i +" : ---------------------------------");
                // console.log(contents[i]);
                console.log(contents[i].title);
            }

            console.dir(" --------------- End Body ------------------");

            console.dir('Total articles returned: ' + contents.length);

            done();

        });
    });

    xit("1.2. Get public articles - call function",function(){

        console.dir(" --------------- 1.2. Get public articles - call function ------------------");

        fapi_func.__api_ReturnTotalRecentArticles().then(function(articles){
            for(let i=0;i<articles.length;i++){
                // console.dir("Article " + i +" : ---------------------------------");
                // console.log(articles[i]);
                console.log(articles[i].title);
            }
        });


    });
    

    xit("3.1 Get SRC token",function(done){

        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false, // important, without this option, fail to retrieve token
            "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/msso/dev/login/glob.admin@src.mercer.com",

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(302);


            console.dir(" --------------- 3.2 Use token to get id by name ------------------");
            console.dir(" --------------- Start Body ------------------");

            token = response.headers['authentication'];
            console.log('Token: ' + token);
            console.log('Header - Date: ' + response.headers.date);
            console.log('Header - ContentType: ' + response.headers['content-type']);

            // console.log('body: ' + body);
            console.dir(" --------------- End Body ------------------");

            done();
        });
        // browser.sleep(3000)
    });

    xit("3.2 Get ID by name in Strapi",function(done){


        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events?title=" + eventName,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            console.dir(" --------------- 3.2 Use token to get id by name ------------------");
            console.dir(" --------------- Start Body ------------------");

            let contents = JSON.parse(body);

            console.log('Body - Length: ' + contents.length);
            console.log('Body - ID: ' + contents[0]._id);
            eventID = contents[0]._id;

            console.dir(" --------------- End Body ------------------");


            done();
        });

    });

    xit("3.3 Use SRC token and ID to set status in SRC",function(done){


        console.dir('Token got from previous step: ' + token);

        Request.put({
            rejectUnauthorized: false,
            // 'followRedirect': false,

            'headers': { "Authorization": token, "Content-Type": 'application/json' },

            "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/moderation-content/status/" + eventID,
            'body': JSON.stringify({"id":eventID,"approval_status":status,"type":"event","approved_date":"2020-10-21T01:02:26.508Z"}),

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            console.dir(" --------------- Start Body ------------------");


            console.log('Header - Date: ' + response.headers.date);
            console.log('body: ' + body);


            console.dir(" --------------- End Body ------------------");


            done();
        });

    });

    xit("3.4 Get Status by Name from Strapi",function(done){


        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events?title=" + eventName,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }
            console.dir("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            console.dir(" --------------- 3.4 Get Status by ID ------------------");
            console.dir(" --------------- Start Body ------------------");

            let contents = JSON.parse(body);

            console.log('Body - Length: ' + contents.length);
            console.log('Body - approval_status: ' + contents[0].approval_status);


            console.dir(" --------------- End Body ------------------");


            done();
        });

    });



    it("4.1 Get SRC token - GlobAdmin",function(done){

        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false, // important, without this option, fail to retrieve token
            "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/msso/dev/login/glob.admin@src.mercer.com",

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }

            console.dir(" --------------- 4.1 Get SRC token - GlobAdmin ------------------");

            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(302);


            token = response.headers['authentication'];
            console.log('Token: ' + token);
            console.log('Header - Date: ' + response.headers.date);
            console.log('Header - ContentType: ' + response.headers['content-type']);

            // console.log('body: ' + body);

            done();
        });
        // browser.sleep(3000)
    });

    it("4.2 Publish EVent in SRC",function(done){

        // console.dir('Token got from previous step: ' + token);

        Request.post({
            rejectUnauthorized: false,
            // 'followRedirect': false,
            // 'headers': { "Authorization": token, "Content-Type": 'application/json' },
            'headers': { "Authorization": token },
            "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/events/create-event-form",
            'formData': {
                'content': JSON.stringify({
                            "title": eventName,
                            "regions": ["5c595b36d6a9907323003632"],
                            "taxonomies": ["5c616ae4e52cc2355e1a1031"],
                            "tags": "technology",
                            "excerpt": "Test_Auto excerpt",
                            "content": "<p>Test_Auto content</p>",
                            "company": {
                                "company_name": "CompAuto",
                                "company_domains": "src.mercer.com",
                                "size": "$5B to $10B",
                                "website": "",
                                "description": "",
                                "twitter": "",
                                "linkedIn": "",
                                "facebook": "",
                                "tags": "",
                                "sfdc_id": "id_4568217",
                                "row_id": "",
                                "onecode": "",
                                "global_rel_mgr_email": "",
                                "global_rel_mgr_legal_name": "",
                                "global_rel_mgr_emplid": "",
                                "global_rel_mgr_sfdc_id": "",
                                "num_of_emp_db": null,
                                "current_year_revenue": null,
                                "prior_year_revenue": null,
                                "client_type": "",
                                "addresses": {
                                    "list": [{
                                        "country": null,
                                        "state": null,
                                        "city": null,
                                        "zip_code": null,
                                        "phone": null
                                    }]
                                },
                                "location": {},
                                "disclaimer": "",
                                "company_status": "active",
                                "followers_count": 1,
                                "business_role": "Mercer Consultant",
                                "taxonomies": [],
                                "regions": null,
                                "sectors": null,
                                "_id": "5d47d70a07ea03001d99760f",
                                "is_featured": false,
                                "last_updated_date": null,
                                "disabled_users": false,
                                "disabled_content": false,
                                "createdAt": "2019-08-05T07:13:14.422Z",
                                "updatedAt": "2019-08-06T10:00:55.614Z",
                                "__v": 0,
                                "id": "5d47d70a07ea03001d99760f",
                                "logo": null
                            },
                            "type": "Webinar",
                            "start_date": "2020-10-22T06:00:00.000Z",
                            "end_date": "2020-10-24T14:00:00.000Z",
                            "location": "San Francisco, United States",
                            "content_url": "https://test.com/",
                        }),
                'action': 'submit'

            }

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }



            console.dir(" --------------- 4.2 Publish EVent in SRC ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(201);


            console.log('Header - Date: ' + response.headers.date);
            // console.log('body: ' + body);



            done();
        });
    });

    it("4.3 Get Event Status by Name in Strapi",function(done){


        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events?title=" + eventName,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }

            console.dir(" --------------- 4.3 Get Event Status by Name from Strapi ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            let contents = JSON.parse(body);

            console.log('Body - Length: ' + contents.length);
            console.log('Body - approval_status: ' + contents[0].approval_status);



            done();
        });

    });

    it("4.4 Get ID by name in Strapi",function(done){

        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events?title=" + eventName,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }



            console.dir(" --------------- 4.4 Get ID by name in Strapi ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            let contents = JSON.parse(body);

            console.log('Body - Length: ' + contents.length);
            console.log('Body - ID: ' + contents[0]._id);
            eventID = contents[0]._id;

            done();
        });

    });

    it("4.5 Use SRC token and ID to set status in SRC",function(done){

        // console.dir('Token got from previous step: ' + token);

        Request.put({
            rejectUnauthorized: false,
            // 'followRedirect': false,

            'headers': { "Authorization": token, "Content-Type": 'application/json' },

            "url": "https://src.us-east-1.dev.awsapp.mercer.com/v1/api/moderation-content/status/" + eventID,
            'body': JSON.stringify({"id":eventID,"approval_status":"approved","type":"event","approved_date":"2020-10-21T01:02:26.508Z"}),

        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }



            console.dir(" --------------- 4.5 Use SRC token and ID to set status in SRC ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);

            console.log('Header - Date: ' + response.headers.date);
            console.log('body: ' + body);




            done();
        });
    });

    it("4.6 Get Event Status by Name from Strapi after approval",function(done){


        Request.get({
            rejectUnauthorized: false,
            'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events?title=" + eventName,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }



            console.dir(" --------------- 4.6 Get Event Status by Name from Strapi after approval ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);


            let contents = JSON.parse(body);

            console.log('Body - Length: ' + contents.length);
            console.log('Body - approval_status: ' + contents[0].approval_status);



            done();
        });

    });

    it("4.7 Delete Event by ID in Strapi",function(done){

        Request.delete({
            rejectUnauthorized: false,
            // 'followRedirect': false,

            'headers': { "Authorization": token_strapi },
            "url": "https://strapi.src.us-east-1.dev.awsadmin.mercer.com/events/" + eventID,


        }, (error, response, body) => {
            if(error) {
                return console.dir(error);
            }


            console.dir(" --------------- 4.7 Delete Event by ID in Strapi ------------------");
            console.log("Response Code ****:"+response.statusCode);
            expect(response.statusCode).toBe(200);

            let contents = JSON.parse(body);
            console.log('Body - Title: ' + contents.title);
            console.log('Body - ID: ' + contents._id);



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