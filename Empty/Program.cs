using System;

/*
 * muy importante:
 *  Grupos de aplicaciones
 *   Applicacion
 *    Configuracion Avanzada
 *     Cargar perfil de usuario -> false
 */

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/get/", () => "GET");


app.MapPost("/post/", async (HttpRequest request) => 
{
    var xmlFile = await request.ReadFromJsonAsync<XmlFile>();
    if (Security.pass != xmlFile.key) return "BAD REQUEST";
    String xmlUrl = xmlFile.file_name+".xml";
    System.IO.File.WriteAllText("C:\\BABEL\\FACTURAS\\" + xmlUrl, xmlFile.file_content);
    return xmlFile.file_name;
});

app.Run();


class XmlFile
{ 
    public string key { get; set; }
    public string file_name { get; set; }
    public string file_content { get; set; }
}

class Security
{
    public static String pass = "asdf.a.6ae46a.ty.65ee5.j.srthse5ywe5yerhsrgsadr%%sdfgsdfgdsfysdtys";
}