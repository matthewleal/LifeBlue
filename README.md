# LifeBlue
LifeBlue Non PHP Interview Code

## Tech Stack
- .NET 6.0 Api
- Hosted in Azure: https://as-lifeblue-customer-api.azurewebsites.net/swagger/index.html
- SQL backend
  - Server: as-lifeblue-techskills-3-server.database.windows.net
  - Database: LifeBlue
  - Table: VisitorInformation
- Table Schema
  - Id - int (PK)
  - Name - varchar(50), not null
  - Email - varchar(50), not null
  - Address - varchar(50), not null
  - Phone - varchar(50), not null
  - LowBudget - int, not null
  - HighBudget - int, not null
  - CreateDate - int, default is GETUTCDATE()
 
## Payload Information
### Visitor Controller
#### Get Visitor
- URL: /api/visitor/{id}
- Verb: GET
- Returns
  - 200 - with Json payload (see below)
  - 404 - not found 
- Return Json Payload
```json
{
  "visitorInformation": {
    "id": 2,
    "name": "Phillip Fry",
    "email": "fry@globalexpress.net",
    "address": "456 Global Express Ln",
    "phone": "281-330-8004",
    "lowBudget": 100000,
    "highBudget": 200000
  }
}
```
#### POST
- URL: /api/visitor/save
- Verb: POST
- Returns
  - 201 - Created with Json payload (see below)
  - 400 - Bad Request
- Request Json Payload Example
```json
{
  "name": "Max Johnson",
  "email": "maxJohnson14@tamu.edu",
  "address": "650 University Dr",
  "phone": "469-555-7788",
  "budget": "500000 to 750000"
}
``` 
- Return Json Payload 201
```json
{
  "visitorInformation": {
    "id": 5,
    "name": "Max Johnson",
    "email": "maxJohnson14@tamu.edu",
    "address": "650 University Dr",
    "phone": "469-555-7788",
    "lowBudget": 500000,
    "highBudget": 750000
  }
}
```
- Return Json Payload 400
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-304c7486cfdb8c8162bf31409fdde6d3-3ded89cffc564bc5-00",
  "errors": {
    "Name": [
      "The Name field is required."
    ]
  }
}
```
## Notes
- Currently no authentication for the API, but in a real-world situation, there would be an API key or OAuth 2.0 used
- Currently no validation done outside of basic Json requirements, but in a real-world situation, we would pair with the client to determine how they wanted the validation errors returned and which validation rules to use
- Current database password is seen in the development settings, but in a real world situation, this would be done through managed identity or key vault
- Currently no logging, but in a real-world situation a logging suite with event tracing would be available
- Currently took the cURL the client suggested, but in a real-world situation, we'd suggest other data points such as city, state, zip, and making sure the budget had a low and high range

