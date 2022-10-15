# NetCore
This is new netCore


For installing dependencu You can copy this code to Netcore 

```
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.7">
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  <PrivateAssets>all</PrivateAssets>
</PackageReference>
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="6.0.7" />

<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.7">
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  <PrivateAssets>all</PrivateAssets>
</PackageReference>
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="6.0.7" />


```

or install it through nugget package

to run migration command

```
(Choose one command bellow)
Add-Migration InitialDatabase  or  EntityFrameworkCore\Add-Migration InitialDatabase

Update-Database

```

Happy Coding

