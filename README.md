## DB Updates

```
# In src directory
dotnet ef migrations add Init -p .\Infrastructure -s .\WebUI -o .\Persistence\Migrations
dotnet ef -s .\WebUI database update
```