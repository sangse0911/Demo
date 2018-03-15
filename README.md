# Demo

Demo 1 project đơn giản dùng c# với entity

Cài đặt: 
+ clone project
+ cài package còn thiếu như entity, microsoft.asp.identity
+ cài đặt webconfig bằng connectionString(< add name="DemoConnection" connectionString="Data Source=.;Initial Catalog=Blog;Integrated Security=true" providerName="System.Data.SqlClient" / >)
+ chạy Enable-Migrations
+ chạy Add-Migration [new migration]
+ chạy Update-Database
