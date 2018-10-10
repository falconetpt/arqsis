FROM microsoft/dotnet:sdk

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Development"

#Unit Testing

# Copy files to app directory
COPY . /app
# Set working directory
WORKDIR /app/Arqsis


# Restore NuGet packages
RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

#ENV ASPNETCORE_ENVIRONMENT="STAGGING"
# Run the app
ENTRYPOINT ["dotnet", "run"] 