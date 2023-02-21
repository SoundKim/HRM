

# HRM
MVC Controller VS WEB API Controller

MVC Controller 
- Used for ASP.NET MVC framework
- Returning view, a redirect, or a JSON result
- Typically have actions that are mapped to specific URL
- class SampleController : Controller


API Controller
- Used for RESTful web services
- processing incoming HTTP requests
- returning the appropriate response in JSON format
- not tied to any particular view or UI
- class SampleController : ControllerBase

