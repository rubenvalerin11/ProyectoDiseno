# 🚀 GUÍA DE INSTALACIÓN Y PRUEBA

## Requisitos Previos

- .NET 8 SDK instalado
- Visual Studio 2026 Community o superior
- Git instalado
- Navegador moderno (Chrome, Firefox, Edge)

---

## 📥 Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/rubenvalerin11/ProyectoDiseno.git
cd ProyectoDiseno
```

### 2. Restaurar Dependencias

```bash
dotnet restore
```

### 3. Compilar Proyecto

```bash
dotnet build
```

### 4. Ejecutar Aplicación

#### Opción A: Desde Terminal
```bash
dotnet run
```

#### Opción B: Desde Visual Studio
- Abrir `ProyectoDiseno.sln`
- Presionar `F5` o click en "Ejecutar"

La aplicación se abrirá en: `https://localhost:5001`

---

## 🧪 Plan de Prueba

### ✅ Solicitud 1: Registro de Clientes

**Pasos:**
1. Navegar a "Clientes"
2. Llenar formulario:
   - Cédula: `123456789`
   - Nombre: `Juan`
   - Apellido 1: `Pérez`
   - Apellido 2: `García`
3. Click en "Guardar cliente"

**Resultado esperado:**
- ✅ Mensaje de éxito: "Cliente guardado correctamente"
- ✅ Cliente aparece en tabla debajo
- ✅ Formulario se limpia

**Validaciones:**
- Dejar campo vacío y click guardar → Debe mostrar error
- Ingresar datos duplicados → Debe mostrar error

---

### ✅ Solicitud 2: Visualización de Clientes

**Pasos:**
1. Registrar varios clientes (según pasos anteriores)
2. Observar tabla

**Resultado esperado:**
- ✅ Tabla muestra todos los clientes registrados
- ✅ Columnas: Cédula, Nombre, Apellido 1, Apellido 2
- ✅ Si no hay clientes, mostrar mensaje "No hay clientes registrados"

---

### ✅ Solicitud 3: Calculadora

**Prueba 1: Suma**
1. Navegar a "Calculadora"
2. Ingresar: `10 + 5`
3. Click en `=`

**Resultado esperado:**
- ✅ Resultado: `22.5` (15 × 1.5)
- ✅ Color AZUL en resultado
- ✅ Historial actualiza

**Prueba 2: Resta**
1. Ingresar: `20 - 5`
2. Click en `=`

**Resultado esperado:**
- ✅ Resultado: `22.5` (15 × 1.5)
- ✅ Color ROJO en resultado

**Prueba 3: Multiplicación**
1. Ingresar: `3 * 4`
2. Click en `=`

**Resultado esperado:**
- ✅ Resultado: `18` (12 × 1.5)
- ✅ Color VERDE en resultado

**Prueba 4: División**
1. Ingresar: `30 / 2`
2. Click en `=`

**Resultado esperado:**
- ✅ Resultado: `22.5` (15 × 1.5)
- ✅ Color PÚRPURA en resultado

**Prueba 5: Botón C (Limpiar)**
1. Ingresar: `5 + 3`
2. Click en `C`

**Resultado esperado:**
- ✅ Display se vacía
- ✅ Resultado desaparece

---

### ✅ Solicitud 6: Colores por Operación

| Operación | Color Esperado | Hexadecimal |
|-----------|----------------|-------------|
| Suma | Azul | #0d6efd |
| Resta | Rojo | #dc3545 |
| Multiplicación | Verde | #198754 |
| División | Púrpura | #6f42c1 |

**Prueba:** Realizar cada operación y verificar color del resultado

---

### ✅ Solicitud 7: División por Cero

**Pasos:**
1. En calculadora, ingresar: `5 / 0`
2. Click en `=`

**Resultado esperado:**
- ✅ Alerta: "❌ Error: No se puede dividir entre cero"
- ✅ Mensaje en pantalla rojo
- ✅ Display no cambia

---

### ✅ Solicitud 4: Exportar XML

**Pasos:**
1. Registrar algunos clientes
2. Ir a "Archivos"
3. Click en "Exportar XML"

**Resultado esperado:**
- ✅ Se descarga archivo `clientes_YYYYMMDD.xml`
- ✅ Archivo contiene estructura XML válida
- ✅ Incluye todos los clientes registrados

**Validar contenido:**
```xml
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfCliente ...>
  <Cliente>
    <Cedula>123456789</Cedula>
    <Nombre>Juan</Nombre>
    <Apellido1>Pérez</Apellido1>
    <Apellido2>García</Apellido2>
  </Cliente>
</ArrayOfCliente>
```

---

### ✅ Solicitud 5: Exportar JSON

**Pasos:**
1. Registrar algunos clientes
2. Ir a "Archivos"
3. Click en "Exportar JSON"

**Resultado esperado:**
- ✅ Se descarga archivo `clientes_YYYYMMDD.json`
- ✅ Archivo contiene JSON válido
- ✅ Incluye todos los clientes registrados

**Validar contenido:**
```json
[
  {
    "cedula": "123456789",
    "nombre": "Juan",
    "apellido1": "Pérez",
    "apellido2": "García"
  }
]
```

---

### ✅ Solicitud 8: Leer XML Dinámicamente

**Pasos:**
1. Ir a "Lecturas"
2. Click en "📋 Leer XML"

**Resultado esperado:**
- ✅ Tabla "Datos desde XML" se llena
- ✅ Muestra datos del archivo `wwwroot/data/clientes.xml`
- ✅ Columnas: Cédula, Nombre, Apellido 1, Apellido 2
- ✅ Sin recargar página

---

### ✅ Solicitud 9: Leer JSON Dinámicamente

**Pasos:**
1. Ir a "Lecturas"
2. Click en "📄 Leer JSON"

**Resultado esperado:**
- ✅ Tabla "Datos desde JSON" se llena
- ✅ Muestra datos del archivo `wwwroot/data/clientes.json`
- ✅ Columnas: Cédula, Nombre, Apellido 1, Apellido 2
- ✅ Sin recargar página

**Prueba adicional:**
1. Click en "Leer JSON" nuevamente
2. Luego click en "Leer XML"

**Resultado esperado:**
- ✅ Ambas tablas se cargan sin conflicto

---

### ✅ Solicitud 10: Historial de Operaciones

**Pasos en Calculadora:**
1. Realizar 3-4 operaciones:
   - `5 + 3 =`
   - `10 - 2 =`
   - `4 * 3 =`
2. Ver panel "Historial de Operaciones" a la derecha

**Resultado esperado:**
- ✅ Listado de operaciones en tiempo real
- ✅ Formato: `5 + 3 = 12` (considerando x1.5)
- ✅ Botón ✕ para eliminar operaciones individuales

**Pasos en Historial:**
1. Ir a "Historial"

**Resultado esperado:**
- ✅ Lista completa de todas las operaciones
- ✅ Números identificadores (#1, #2, etc.)
- ✅ Botón para limpiar todo
- ✅ Se actualiza automáticamente

---

## 🔍 Pruebas Adicionales

### Prueba de Responsividad
1. Abrir en navegador
2. Presionar F12 (Dev Tools)
3. Cambiar a dispositivo móvil (375px ancho)

**Resultado esperado:**
- ✅ Interfaz se adapta correctamente
- ✅ Botones son accesibles
- ✅ Tablas son scrolleables

### Prueba de LocalStorage
1. Realizar operaciones en calculadora
2. Refrescar la página (F5)
3. Ir a "Historial"

**Resultado esperado:**
- ✅ Historial permanece después de refresh
- ✅ Datos persisten en localStorage

### Prueba de Validaciones AJAX
1. Abrir Dev Tools (F12)
2. Ir a Clientes
3. Intentar guardar sin completar campos

**Resultado esperado:**
- ✅ Sin petición AJAX si hay campos vacíos
- ✅ Validación en cliente antes de enviar

---

## 📊 Checklist de Validación

```
SOLICITUD 1: REGISTRO DE CLIENTES
  ☐ Formulario muestra 4 campos
  ☐ AJAX funciona sin recargar
  ☐ Validación de campos requeridos
  ☐ Mensaje de éxito/error

SOLICITUD 2: VISUALIZACIÓN
  ☐ Tabla muestra clientes
  ☐ Se actualiza al agregar
  ☐ Mensaje cuando está vacía

SOLICITUD 3: CALCULADORA
  ☐ Números 0-9 funcionan
  ☐ Suma funciona
  ☐ Resta funciona
  ☐ Multiplicación funciona
  ☐ División funciona
  ☐ Botón C funciona
  ☐ Resultado multiplicado por 1.5
  ☐ Display muestra resultado

SOLICITUD 4: EXPORTAR XML
  ☐ Botón descarga XML
  ☐ Archivo válido
  ☐ Contiene datos correctos

SOLICITUD 5: EXPORTAR JSON
  ☐ Botón descarga JSON
  ☐ Archivo válido
  ☐ Contiene datos correctos

SOLICITUD 6: COLORES
  ☐ Suma: Azul
  ☐ Resta: Rojo
  ☐ Multiplicación: Verde
  ☐ División: Púrpura

SOLICITUD 7: DIVISIÓN POR CERO
  ☐ Detecta división por 0
  ☐ Muestra error
  ☐ Alert funciona

SOLICITUD 8: LEER XML
  ☐ Botón "Leer XML" funciona
  ☐ Tabla se llena
  ☐ Datos son correctos

SOLICITUD 9: LEER JSON
  ☐ Botón "Leer JSON" funciona
  ☐ Tabla se llena
  ☐ Datos son correctos

SOLICITUD 10: HISTORIAL
  ☐ Historial muestra operaciones
  ☐ Se actualiza en tiempo real
  ☐ Se persiste en navegador
  ☐ Página de historial funciona
```

---

## 🐛 Solución de Problemas

### "No se carga la página"
- ✅ Verificar que .NET 8 está instalado: `dotnet --version`
- ✅ Restaurar dependencias: `dotnet restore`
- ✅ Limpiar y recompilar: `dotnet clean && dotnet build`

### "Puerto 5001 en uso"
```bash
dotnet run --urls https://localhost:5002
```

### "Archivos JSON/XML no se encuentran"
- ✅ Verificar que existen en `wwwroot/data/`
- ✅ Revisar permisos de lectura
- ✅ Crear carpeta si no existe

### "LocalStorage no funciona"
- ✅ Verificar que no está en "modo privado"
- ✅ Limpiar cookies del sitio
- ✅ Usar navegador moderno (Chrome 4+, Firefox 3.5+)

---

## 📈 Métricas de Éxito

| Métrica | Objetivo | Estado |
|---------|----------|--------|
| Todas solicitudes | 100% completadas | ✅ |
| Código compilación | 0 errores | ✅ |
| Validaciones | Funcionando | ✅ |
| Responsividad | Mobile + Desktop | ✅ |
| Documentación | Completa | ✅ |
| Persistencia datos | LocalStorage | ✅ |

---

## 🎓 Notas para Presentación

### Puntos Fuertes del Proyecto

1. **Funcionalidad**: Todas las solicitudes completadas
2. **Validaciones**: Dobles (cliente + servidor)
3. **UX**: Interfaz amigable e intuitiva
4. **Persistencia**: Datos guardados localmente
5. **Documentación**: Completa y clara
6. **Diseño**: Moderno y responsivo

### Demostraciones Recomendadas

1. **Registrar cliente** → Ver en tabla
2. **Calculadora** → Mostrar colores diferentes
3. **División por cero** → Mostrar validación
4. **Exportar** → Descargar JSON/XML
5. **Importar** → Cargar datos
6. **Lecturas dinámicas** → Leer archivos
7. **Historial** → Mostrar persistencia

---

## 📞 Contacto y Soporte

- **Repositorio**: https://github.com/rubenvalerin11/ProyectoDiseno
- **Rama Principal**: `main`
- **Último Commit**: Implementación completa de 10 solicitudes

---

**¡Proyecto listo para demostración y evaluación!** 🎉

---
