# CLEAN-ARCH_DOTNET

Basic project with "Clean Architetucture" application and "DDD"

### Create Migration

* Open "Tools -> Nuget manager package -> Console"
  
* Select "CleanArch.Infra.Data" as a default project and run

		Add-Migration MIGRATION_NAME

### Update Database

* Open "Tools -> Nuget manager package -> Console"
  
* Select "CleanArch.Infra.Data" as a default project and run

		update-database
