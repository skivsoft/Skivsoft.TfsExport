# Skivsoft.TfsExport
Export data from TFS using REST API into target database.

## Features

* Export pull-requests from TFS into database
* Export work items assigned to pull-requests into database

## Configuration

The program need to be configured before using. Settings are located in the ````Skivsoft.TfsExport.exe.config```` file.

* SourceTfsUrl (e.g. "https://my-tfs.domain/tfs/myproject")
* SourceTfsRepositoryName (e.g. "MyRepository")
* SourceTfsUsername
* SourceTfsPassword
* TargetConnectionString (e.g. "Server=localhost\SQLEXPRESS;Database=TFSEXPORT;Trusted_Connection=True;")