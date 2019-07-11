using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DatingApp.Api
{
    public class Program
    {
        //angular is client side framework
        // nodejs is server side java script run time
        // nodejs comes with npm which is package eco system that manages packages and their dependencies
        // dotnet -h
        // dotnet new -h
        // dotnet new webapi -h
        //dotnet new webapi -o DatingApp.API -n DatingApp.API
        //To launch use the command code .
        //download c# for visual studio code. if update failed upgrade vs code and then upgrade
        //download c# ide extensions for VS Code
        //download nuget package manager. for angular we use npm package. reload after installation
        //to run use dotnet run or dotnet watch run
        //to add nuget use ctrl+shift+p >nuget add package
        //to add incremental migration run the following command to add classes to migration folder. 
        //the datacontextmodelsnapshot.cs is entityfw to keep track which migration is applied
        //initialcreatedesigner.cs purely used to designed what to remove from datacontextmodelsnapshop
        //initialcreate has up (create or change db or tables. here Values is the table with 2 columns id and name. uses id as primary key by default) and down (if we want to roll back this will drop table and values)
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update this creates datingapp.db
        //download angular cli
 	    //angular cli contains is the angular equivalent of .net cli
        //npm install -g @angular / cli@6.0.8
        //TO create new angular project type ng new DatingApp-SPA
        //IN visual studio 2019 by right clicking and add existing web site
        //NO NEED to download extensions
        //e2e folder is end to end testing
        //node_modules contains list of files
        //package.json will tell all packages that are downloaded and inside node_modules folder. also this contains dependencies. this contains npm scripts which tell commands to run
        //src folder is the location where we write the code. in app-> there are .cs files
        //app.component.ts and app.module.ts (every appln has atleast 1 file and had bootstrap information Appcomponent. the app.component.ts contains component code)
        //in component there is a selector app-root and template url and css url
        //the app-root in index.html comes from appcomponent
        //main.ts tells we are making web based application in browser
        //angular.js tells the configuration from webpack. it contains options like outputpath, index, main etc
        //to launch the site type cd datingapp-spa
        //now do ng serve (if compilation issues are found run the command: npm install rxjs@6.0.0 --save)
        //when the browser is clicked output will be java script as browser cannot understand typescript
        //download extension manager
        //first get angular snippets by john papa, angular files 1.6.2, angular language service (this can tell which methods are written)
        //angular2 switcher (helps to switch between component file to html file because of shortcut keys), auto rename tagm, bracket pair colorizer,
        //debugger for chrome, material icon theme, path intellisense, prettier, tslint
        //create a new component in app folder called value. this will add css, html, spec.ts and component.ts
        //in app.module.cs valuecomponent is automatically added
        
        //into app.module.cs the import http client module first the name space and the imports section to make web api call
            //import {HttpClientModule} from '@angular/common/http'; //IN IMPORT section add HttpClientModule
            
        //in value.component.ts define getvalue method, update constuctor with http:HttpClient and ngoninit to call get values after constructor
        //make sure the value.component.ts has import { HttpClient } from '@angular/common/http';
        //in appcomponent.html add <app-value></app-value>
            //cors (cross origin resource sharing) is security measure which clients are allowed to access api
            //add *ngfor to display values in value.component.html
        //<p *ngFor="let value of values">
        // {{value.id}},{{value.name}}
        //</p>

        //download bootstrap and fontawesome npm install bootstrap font-awesome
        //in style.css add @import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
        //@import '../node_modules/font-awesome/css/font-awesome.min.css'
        //type git for all commands
        //initialize git init
        //git remote add origin https://github.com/RaghuDesiraju/DatingApp.git
        //git commit -m "second commit"
        //git push -u origin master

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// use Kestrel (light weight web server) as the web server and configure it using the application's configuration
        /// Startup class contains startup method
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
