# Instrucciones de desarrollo para AnalyzerWpf

## Ubicaci�n del archivo de log
- El archivo de log de Serilog debe crearse siempre en la carpeta del proyecto fuente:
  `AnalyzerWpf/logs/wpf.log`
- No debe crearse en `bin/Debug` ni en `bin/Release`, sino junto al c�digo fuente.

## Compilaci�n obligatoria
- **No se debe continuar con el desarrollo ni ejecutar nuevas funcionalidades si existen errores de compilaci�n.**
- Todos los errores de compilaci�n deben ser resueltos antes de avanzar.
- El asistente debe informar expl�citamente si hay errores de compilaci�n y no continuar hasta que est�n corregidos.

## Configuraci�n recomendada para Serilog
En `App.xaml.cs`, usa una ruta absoluta para asegurar la ubicaci�n correcta del log:

```csharp
var projectDir = @"C:\w\repos\SummerCamp25\Analyzer\AnalyzerWpf";
var logDir = System.IO.Path.Combine(projectDir, "logs");
if (!System.IO.Directory.Exists(logDir))
    System.IO.Directory.CreateDirectory(logDir);
var logPath = System.IO.Path.Combine(logDir, "wpf.log");
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();
```

## Comprobaci�n de creaci�n del log
- Al iniciar la aplicaci�n, se debe comprobar si el archivo de log se ha creado correctamente.
- Si no se crea, mostrar un mensaje de advertencia con la ruta esperada.

## Buenas pr�cticas
- Mant�n las rutas de log y otros archivos importantes fuera de las carpetas de compilaci�n (`bin`, `obj`).
- Documenta cualquier cambio en la ubicaci�n de archivos en este README.

---

**Actualiza este archivo si cambias la estructura del proyecto o la configuraci�n de Serilog.**
