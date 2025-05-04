# Unity Assets Repository

Repositorio de scripts y utilidades para desarrollo rápido y escalable de videojuegos en Unity.

## 🚀 Características

- Sistema de gestión de juego robusto
- Sistema de eventos y comunicación entre componentes
- Herramientas de UI y gestión de escenas
- Sistema de guardado de datos
- Utilidades para física y audio
- Gestión de inputs del jugador
- Sistema de login y gestión de usuarios

## 📁 Estructura del Proyecto

```
1. SCRIPTS/
├── Core/                    # Componentes fundamentales del juego
│   ├── GameManager/        # Gestión del juego
│   ├── EventSystem/        # Sistema de eventos
│   ├── SaveSystem/         # Sistema de guardado
│   └── Logger/            # Sistema de logging
│
├── Gameplay/               # Mecánicas de juego
│   ├── Input/             # Gestión de inputs
│   ├── Physics/           # Física y colisiones
│   ├── AI/               # Inteligencia artificial
│   └── Mechanics/        # Mecánicas específicas
│
├── UI/                     # Interfaz de usuario
│   ├── Menus/            # Menús y pantallas
│   ├── HUD/              # Interfaz en juego
│   ├── Dialogs/          # Diálogos y textos
│   └── Animations/       # Animaciones UI
│
├── Audio/                  # Sistema de audio
│   ├── Music/            # Música
│   ├── SFX/              # Efectos de sonido
│   └── Voice/            # Voces y diálogos
│
├── Network/               # Funcionalidades online
│   ├── API/              # Conexiones API
│   ├── Multiplayer/      # Juego en red
│   └── Authentication/   # Autenticación
│
├── Utils/                 # Utilidades generales
│   ├── ObjectPool/       # Pool de objetos
│   ├── Extensions/       # Extensiones de Unity
│   └── Helpers/          # Clases auxiliares
│
├── Data/                  # Gestión de datos
│   ├── ScriptableObjects/# Objetos configurables
│   ├── Localization/     # Localización
│   └── Config/           # Configuraciones
│
└── Tests/                # Pruebas y debugging
    ├── UnitTests/        # Pruebas unitarias
    └── DebugTools/       # Herramientas de debug
```

## 🛠️ Requisitos

- Unity 2021.3 o superior
- Visual Studio 2019 o superior
- .NET Framework 4.7.2 o superior

## 📦 Instalación

1. Clona este repositorio en la carpeta Assets de tu proyecto Unity
2. Importa los paquetes necesarios desde el Package Manager
3. Configura las referencias en el GameManager

## 📚 Documentación

Para más información sobre cada componente, consulta la carpeta Documentation.

## 🤝 Contribución

Las contribuciones son bienvenidas. Por favor, sigue las guías de contribución.

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Ver el archivo LICENSE para más detalles.

## 🔧 Configuración Inicial

1. Asegúrate de tener el GameManager en tu escena inicial
2. Configura los prefabs necesarios
3. Ajusta los parámetros según tu proyecto

## 🎮 Uso Básico

```csharp
// Ejemplo de uso del GameManager
GameManager.Instance.InitializeGame();
```

## 📝 Notas de Versión

### v1.0.0
- Versión inicial del repositorio
- Sistema base implementado
- Documentación básica
