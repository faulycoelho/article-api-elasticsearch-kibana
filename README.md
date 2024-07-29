How to
1. Start the application using Docker Compose:
```docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" up```

2. Check if the application is healthy:
https://localhost:8081/health

Expected Result:
```{
  "status": "Healthy",
  "totalDuration": "00:00:00.0034000",
  "entries": {
    "elasticsearch": {
      "data": {},
      "duration": "00:00:00.0030161",
      "status": "Healthy",
      "tags": []
    }
  }
}```

3. Use the API to produce data:
![image](https://github.com/user-attachments/assets/6101e745-af92-467b-bc32-bdb954ff8016)

4. Create your own Index and Dashboard in Kibana.
You can read more how to do it in my article: https://medium.com/@faulybsb/net-web-eb-api-with-elasticsearch-and-kibana-e26c6eba27b3
