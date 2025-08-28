# Instrucciones de desarrollo para AnalyzerWpf

## Ubicación del archivo de log
- El archivo de log de Serilog debe crearse siempre en la carpeta del proyecto fuente:
  `AnalyzerWpf/logs/wpf.log`
- No debe crearse en `bin/Debug` ni en `bin/Release`, sino junto al código fuente.

## Compilación obligatoria
- **No se debe continuar con el desarrollo ni ejecutar nuevas funcionalidades si existen errores de compilación.**
- Todos los errores de compilación deben ser resueltos antes de avanzar.
- El asistente debe informar explícitamente si hay errores de compilación y no continuar hasta que estén corregidos.

## Configuración recomendada para Serilog
En `App.xaml.cs`, usa una ruta absoluta para asegurar la ubicación correcta del log:

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

## Comprobación de creación del log
- Al iniciar la aplicación, se debe comprobar si el archivo de log se ha creado correctamente.
- Si no se crea, mostrar un mensaje de advertencia con la ruta esperada.

## Buenas prácticas
- Mantén las rutas de log y otros archivos importantes fuera de las carpetas de compilación (`bin`, `obj`).
- Documenta cualquier cambio en la ubicación de archivos en este README.

---

**Actualiza este archivo si cambias la estructura del proyecto o la configuración de Serilog.**
