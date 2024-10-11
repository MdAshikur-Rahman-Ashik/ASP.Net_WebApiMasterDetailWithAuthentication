<h1>🔑 ASP.NET MVC & Web API Master-Detail with Authentication</h1>

<p>This project is a combination of ASP.NET MVC and Web API, implementing master-detail relationships with authentication. It includes features for managing master-detail data and secure user authentication.</p>

<h2>📑 Table of Contents</h2>
<ul>
  <li><a href="#features">Features</a></li>
  <li><a href="#technologies">Technologies</a></li>
  <li><a href="#getting-started">Getting Started</a></li>
  <li><a href="#database-setup">Database Setup</a></li>
  <li><a href="#configuration">Configuration</a></li> <!-- Added Configuration section -->
  <li><a href="#usage">Usage</a></li>
  <li><a href="#contributing">Contributing</a></li>
  <li><a href="#license">License</a></li>
</ul>

<h2 id="features">🚀 Features</h2>
<ul>
  <li>Master-Detail data management.</li>
  <li>Secure user authentication and authorization.</li>
  <li>RESTful API endpoints for CRUD operations.</li>
  <li>Entity Framework Code First approach.</li>
  <li>Responsive design with Bootstrap integration.</li>
</ul>

<h2 id="technologies">🛠️ Technologies</h2>
<ul>
  <li><strong>Frontend:</strong> ASP.NET MVC, Razor Views, Bootstrap</li>
  <li><strong>Backend:</strong> ASP.NET Web API</li>
  <li><strong>Database:</strong> SQL Server (Code First)</li>
  <li><strong>ORM:</strong> Entity Framework (Code First)</li>
</ul>

<h2 id="getting-started">⚙️ Getting Started</h2>

<h3>🔧 Prerequisites</h3>
<p>Make sure you have the following installed:</p>
<ul>
  <li><a href="https://visualstudio.microsoft.com/" target="_blank">Visual Studio</a> (v2019 or later)</li>
  <li><a href="https://dotnet.microsoft.com/download" target="_blank">.NET Framework 4.7.2 or later</a></li>
  <li><a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank">SQL Server</a> (or SQL Server Express)</li>
</ul>

<h2 id="database-setup">📂 Database Setup</h2>
<ol>
  <li>Clone the repository:</li>
  <pre><code>https://github.com/MdAshikur-Rahman-Ashik/ASP.Net_MvcApi_WebApiMasterDetailWithAuthentication</code></pre>
  
  <li>Navigate to the project directory and enable migrations:</li>
  <pre><code>Enable-Migrations</code></pre>

  <li>Add the initial migration:</li>
  <pre><code>Add-Migration Init</code></pre>

  <li>Update the database:</li>
  <pre><code>Update-Database</code></pre>
</ol>

<h2 id="configuration">🔧 Configuration</h2>
<h3>App_Start Folder</h3>
<p>
  The <strong>App_Start</strong> folder contains important configuration files. You will find the following classes here:
</p>
<ul>
  <li><strong>RouteConfig.cs:</strong> This is where you define the routing patterns for your application.</li>
  <li><strong>FilterConfig.cs:</strong> Used to register global filters (e.g., error handling).</li>
  <li><strong>BundleConfig.cs:</strong> Handles the bundling and minification of CSS and JS files.</li>
  <li><strong>WebApiConfig.cs:</strong> This file is used to configure Web API routes and other settings for the Web API.</li>
</ul>

<h3>WebApiConfig.cs</h3>
<p>The <strong>WebApiConfig.cs</strong> file is responsible for setting up Web API routes and any other related configuration. It is located in the <code>App_Start</code> folder. The following is an example configuration:</p>
<pre><code> public static class WebApiConfig
 {
     public static void Register(HttpConfiguration config)
     {
         config.Formatters.Add(new MultiPartFormDataFormater());
         config.MapHttpAttributeRoutes();
         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );
     }
 }
</code></pre>


<h3>Images Folder</h3>
<p>Create an <strong>Images</strong> folder under the root of your project to store images. Add screenshots or other media assets to this folder. Example:</p>
<pre><code>project-root/
│
├── App_Start/
├── Controllers/
├── Images/   <!-- Create this folder -->
│   ├── screenshot1.png
│   └── screenshot2.png
└── Views/
</code></pre>

<h2 id="usage">💻 Usage</h2>
<ul>
  <li>Create, read, update, and delete master-detail records via the Web API.</li>
  <li>Authentication functionality ensures secure access to the application.</li>
</ul>

<h3>📬 Testing with Postman</h3>
<p>You can use <a href="https://www.postman.com/" target="_blank">Postman</a> to test the Web API endpoints. Here are the basic steps to check and post data:</p>

<h4>1. Base URL</h4>
<p>Make sure to use the correct base URL for your API, typically:</p>
<pre><code>https://localhost:{port}/api/</code></pre>

<h4>2. Testing GET Requests</h4>
<p>To retrieve master or detail records, make a GET request in Postman:</p>
<pre><code>GET https://localhost:{port}/api/{controller}</code></pre>
<p>Example for retrieving products:</p>
<pre><code>GET https://localhost:5001/api/products</code></pre>

<h4>3. Testing POST Requests (Creating a Product)</h4>
<p>To create a new product, make a POST request with the following JSON body:</p>
<pre><code>POST https://localhost:{port}/api/products</code></pre>
<p>Example JSON Body:</p>
<pre><code>{
  "ProductName": "Sample Product",
  "Price": 150,
  "Quantity": 10
}
</code></pre>
<p>Ensure that in Postman, you set the request body type to <strong>raw</strong> and select <strong>JSON</strong>.</p>

<h4>4. Testing PUT Requests (Updating a Product)</h4>
<p>To update an existing product, make a PUT request with the JSON body:</p>
<pre><code>PUT https://localhost:{port}/api/products/{id}</code></pre>
<p>Example:</p>
<pre><code>PUT https://localhost:5001/api/products/1</code></pre>

<h4>5. Testing DELETE Requests</h4>
<p>To delete a product, make a DELETE request:</p>
<pre><code>DELETE https://localhost:{port}/api/products/{id}</code></pre>
<p>Example:</p>
<pre><code>DELETE https://localhost:5001/api/products/1</code></pre>

<h4>6. Testing Master-Detail Data (Order and Product)</h4>
<p>For a master-detail relationship like orders containing products, you can post data to <strong>OrderItem</strong> like this:</p>
<pre><code>POST https://localhost:{port}/api/orderitems</code></pre>
<p>Example JSON Body for adding a product to an order:</p>
<pre><code>{
  "OrderId": 100,
  "ProductId": 1,
  "Quantity": 3,
  "Price": 450
}
</code></pre>

<h4>7. Authentication</h4>
<p>Ensure that you include any necessary authentication tokens or credentials in the request headers if authentication is required.</p>





<h2 id="contributing">🤝 Contributing</h2>
<p>Contributions are welcome! If you have suggestions for improvements or want to report issues, please create an issue or submit a pull request.</p>

<h2 id="license">📝 License</h2>
<p>This project is licensed under the MIT License. See the <a href="LICENSE" target="_blank">LICENSE</a> file for more details.</p>

<h2>📧 Contact</h2>
<p>For any questions or suggestions, please contact:</p>
<ul>
  <li><strong>Name:</strong> Md Ashikur Rahman Ashik</li>
  <li><strong>Email:</strong> <a href="mailto:mohammadashikidb@gmail.com">mohammadashikidb@gmail.com</a></li>
</ul>



![Screenshot 1](https://github.com/user-attachments/assets/0874c21d-dbf3-44c8-895d-c9297828e4c1)
![Screenshot 2](https://github.com/user-attachments/assets/04ca245d-8aad-4d24-9752-7aea3a40137d)
