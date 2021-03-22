
You can see the live version of the code in:

<https://juangarcia-test.azurewebsites.net/>



##### TO-DOs:

**Pending due to time limitations.**

* Add unit more unit test scenarios.

* Add error handling and logging with _Decorator_ pattern.

* Add download file in `Details` view.

* Implement `XmlSerializer` (Same logic as `JsonSerializer` but with XML)

* Implement _Factory_ pattern with `ISerializer` to return `JsonSerializer`or `XmlSerializer`.

* Remove hardcoded auth. Not really necessary since its consuming a public API.

* Add more interaction to UI (JQuery with AJAX calls).

* Add a cache layer to avoid making many API requests.

* Divide projects into independent Nuget packages to code reuse.
  