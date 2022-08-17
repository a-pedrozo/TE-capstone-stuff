# Week 7 Pair Project

The goal of this assignment is to practice consuming APIs by testing in Postman and using RestSharp to make REST requests.

## Step 1: Pick an API to interact with

For this assignment you'll need to select at least one API to call that you haven't worked with in class before. Over the course of the pairwork you will be making REST calls to this API and displaying the results to the user.

A few helpful resources for finding APIs:

- [ProgrammableWeb](https://www.programmableweb.com)
    - Example: [Wikipedia](https://www.programmableweb.com/api/wikipedia-rest-api)
- [Public APIs List on GitHub](https://github.com/public-apis/public-apis)

Some tips on picking APIs:

- Avoid anything that requires authentication or any sort of auth / API tokens
    - If you have to create an account, it's not a good pick
    - **Avoid [RapidAPI](https://rapidapi.com/hub)** as it requires you to authenticate and send headers
    
- Keep it simple
    - Try to pick an API that doesn't require a complex object in the request body
    - Try to pick an API that doesn't send back a complex object in the response body
    - GET is great!

- Look for APIs with beginner-friendly documentation
    - If the documentation is lacking, your instructors are unlikely to make additional sense of an API they didn't create
    - Ideally, the documentation should show you what a sample REST Request looks like
    - APIs are unlikely to give you RestSharp code. This is part of your learning process.

- Pick something of interest to _both_ partners. 
    - Remember: both of you are paying for an education and are valuable people. 
    - Teams will reject technically excellent candidates if they feel they will not put the team first

**Once you have selected an API, send your instructor(s) a link to that API via Slack for approval and move on to the next step.** Instructors will look over the selected API within business hours and will warn you if it appears to not be feasible with what you know.

## Step 2: Make a Successful REST Request to that API in Postman

_Before starting: Make sure you have completed step 1._

Using Postman, make a successful REST request to the endpoint you selected and verify that the proper response body and status code comes back.

The response body is something you will use in the next step to build a C# model around.

**When you have one or more API calls that succeed in Postman, take a screenshot and save it in your pair project's screens directory, then proceed to the next step.**

Your screenshot might look something like the following:

![Star Wars API Postman Call](screens/StarWarsPeopleExample.png)

## Step 3: Create the Models as needed in your C# project's "Models" directory

_Before starting: Make sure you have completed steps 1 &amp; 2._

In your C# project for this application, add a new class inside the `Models` directory. Name this class whatever is appropriate, but it should store the response from the server.

If the API you are calling requires an object in the request body for a POST or PUT, you may need to create an additional class in the `Models` directory to represent that object.

You are not required to make a PUT, POST, or DELETE call as part of this pair work.

## Step 4: Make an API Client to the target API with RestSharp

In your C# application, create a _new_ API Client class to represent the API you are interacting with. This class should have a `using RestSharp;` and should create an instance of `RestClient` in the constructor.

Add at least one method to this class to make API calls similar to what you did in Postman in step 2. These methods should return results.

Keep in mind that methods may not complete successfully and may not have success status codes.

## Step 5: Use your API Client to get and display information from the API to the user

Finally, in Program.cs in the CallAdditionalApis method, instantiate and call your API client, then display the results back to the user.

Run your application and ensure you get the same results as you got in Postman.

**When you are finished, add / commit / pull / push and inform your instructor you are finished with the assignment.**