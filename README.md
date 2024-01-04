This small pet project is aimed at show how to get and save same data from different sources.

Imagine you are responsible for collect cars insurance data from a few partner organizations. You have built your own api in order to accept data in json format like this:

>{
  "Insurer": {
    "FirstName": "John",
    "LastName": "Dow"
  },
  "Vehicle": {
    "Mark": "Ford",
    "Model": "Mustang"
  },
  "DateBegin": "2016-06-06",
  "DateEnd": "2017-06-05"
}

But your partners don't want to accept your format or can not accept it for many reasons and they are ready to send you insurance information in that format:
> {
  "InsurerFirstName": "Ivan",
  "InsurerLastName": "Ren"
  "Vehicle": {
    "Mark": "Volvo",
    "Model": "XC90"
  },
  "EffectiveDate": "2016-06-06",
  "ExpirationDate": "2017-06-05"
}

or so:
> {
  "Insurer": {
    "Type": "Person",
    "Person": {
      "InsurerFirstName": "Maria",
      "InsurerLastName": "Mitsar"
    }
},
  "VehicleMark": "Toyota",
  "VehicleModel": "Corolla",
  "DateBegin": "2016-06-06",
  "DateEnd": "2017-06-05"
}

and so on 
Using Jurassic https://www.nuget.org/packages/Jurassic/#readme-body-tab, jsonSchema and mapper.js file we can accept, handle and save differently formated data.

If we face with necessary to add new partners with new format we will extend our json schema and mapper js without recompilling .net code.



