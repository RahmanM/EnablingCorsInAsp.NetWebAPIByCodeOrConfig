To enable CORS:


	a) Through code

			Install-Package Microsoft.AspNet.WebApi.Cors

			var cors = new EnableCorsAttribute("URL OR *", "*", "*");
            config.EnableCors(cors);

			OR:

			 private static void EnableCors(HttpConfiguration config)
			{
				var corsUrls = ConfigurationManager.AppSettings["CorsUrlsConcatinated"].ToString();
				// Note: seems like seeting corsUrls to "http://localhost:16980" does not work. Gets blocked by
				// chrome ??? - some bug but * works!
				// But works for the IE
				var cors = new EnableCorsAttribute(corsUrls, "*", "*");
				config.EnableCors(cors);
			}



	b) through web config

		
			<httpProtocol>
			  <customHeaders>
				<add name="Access-Control-Allow-Origin" value="*" />
				<add name="Access-Control-Allow-Headers" value="Content-Type" />
				<add name="Access-Control-Allow-Methods" value="GET, POST, PUT, DELETE, OPTIONS" />
			  </customHeaders>
			</httpProtocol>