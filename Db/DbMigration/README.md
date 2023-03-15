# DB Migration

This is the project that create database. It is specific only for postgresql.

## How to Use

If you need to add a new table you need to add new class under Domain project into Entities folder where the other scripts are archived. Be careful you must inherit from BaseEntity class which is located in Abstraction Directory.

When you add new entity you must create the configuration for this new entity. In order to do this you should go to EF project and under SchemaConfiguration folder add new file with name {ClassName}Config.cs and you must inherit from `IEntityTypeConfiguration<T>`. After this you need to add DbSet on DataContext file.

When you have done all above steps you need to open Package Manager Console and add new Migration base on patern migr_xxxx_yyyy (xxxx = incremental number and yyyy = current year).

