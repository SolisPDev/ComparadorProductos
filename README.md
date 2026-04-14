# ComparadorProductos# 🧠 Comparador de Productos (v1.0)

Aplicación de consola desarrollada en **.NET + C#** que permite comparar dos archivos CSV de productos y encontrar coincidencias inteligentes basadas en:

- Similitud de texto (descripción)
- Validación por diferencia de precio
- Selección del mejor match por producto

---

## 🚀 Objetivo

Resolver un problema común en integraciones con plataformas como UberEats:

> ¿Cómo mapear automáticamente productos entre distintos catálogos cuando los nombres no coinciden exactamente?

---

## 📂 Entrada de datos

### 🔹 Archivo 1: Catálogo general
Contiene los productos base del sistema.

```csv
Id,Descripcion,Precio
2151,DULCE MENTA MEDIANO,370

🔹 Archivo 2: Productos UberEats

Contiene productos con descripciones distintas (y prefijo "UBER").

Id,Descripcion,Precio
U1089,UBER DULCE MENTA MEDIANO,400


⚙️ Procesamiento

La aplicación realiza:

1. Normalización de texto
Convierte a minúsculas
Elimina acentos
Elimina el prefijo "uber"
Limpia caracteres especiales
Elimina palabras irrelevantes (combo, promo, etc.)

2. Cálculo de similitud
Se utiliza el algoritmo de Levenshtein para medir qué tan similares son dos descripciones.

3. Validación por precio
Se evalúa la diferencia entre precios:
Se favorecen diferencias cercanas a 30 unidades
Se penalizan diferencias grandes

4. Score combinado
scoreFinal = (similitud * 0.7) + (precioScore * 0.3)

5. Mejor match por producto
Para cada producto de Uber:
Se evalúan todos los del catálogo
Se selecciona solo el mejor candidato


📄 Salida

Archivo resultado.csv:

UberId,UberDescripcion,UberPrecio,CatId,CatDescripcion,CatPrecio,Score
U1089,UBER DULCE MENTA MEDIANO,400,2151,DULCE MENTA MEDIANO,370,0.75

🧩 Tecnologías utilizadas
.NET (Console App)
C#
Procesamiento de archivos CSV
Algoritmos de similitud de texto

🧠 Enfoque de desarrollo

Este proyecto fue desarrollado utilizando un enfoque de:
AI-assisted Spec-Driven Development
Definición iterativa de reglas de negocio
Refinamiento progresivo del algoritmo
Validación basada en casos reales

La IA fue utilizada como herramienta de apoyo para acelerar la construcción, sin reemplazar el criterio técnico.

🔜 Próximas mejoras (v2.0)
Matching más inteligente por palabras clave
Exclusión automática de tamaños (chico, grande, etc.)
Optimización de performance (evitar comparación O(n²))
Interfaz para validación manual
Persistencia de matches aprobados

🎯 Caso de uso real

Ideal para:

Integraciones POS ↔ plataformas delivery
Limpieza y homologación de catálogos
Automatización de conciliación de productos

👨‍💻 Autor

Desarrollado como parte de un ejercicio práctico enfocado en resolver problemas reales de integración de datos.

⭐ Nota

Esta es la versión v1.0.
La versión v2.0 incluirá mejoras en precisión, rendimiento y experiencia de usuario.

