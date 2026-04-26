# 7Clicker

Herramienta de automatización de entrada de alta precisión diseñada para la simulación de comportamiento humano. A diferencia de los scripts de automatización estándar que utilizan retrasos estáticos, 7Clicker implementa algoritmos de aleatorización basados en distribución gaussiana y emulación de micro-movimientos en reposo para eludir los sistemas de detección heurística.

**Versión actual:** v1.0 (Nativo C# / WPF)

<img width="434" height="442" alt="{57BD8740-0EFA-4E8D-B294-70C07B9B24BB}" src="https://github.com/user-attachments/assets/6a6a5ce1-ad75-4e15-9c08-5331d0f7b22f" />


## Características Principales

* **Motor de Distribución Gaussiana:** Los clics se generan utilizando curvas de probabilidad matemática (transformada de Box-Muller), eliminando los patrones estáticos predecibles.
* **Modo Fantasma (Human Idle):** Simula la deriva orgánica del ratón y micro-movimientos durante los periodos de espera. Incluye lógica de comportamiento errático (distracciones, variaciones en doble clic).
* **Input a Nivel de Kernel:** Utiliza llamadas directas a `user32.dll` para una ejecución de baja latencia.

## Uso

La aplicación opera en dos modos a través de la interfaz:

1.  **Modo Fantasma (Predeterminado):** Para simulación de navegación errática y de baja frecuencia.
    * *Parámetros:* Tiempo de espera Mín/Máx (Segundos).
    * *Idle Jitter:* Habilita micro-movimientos aleatorios durante la inactividad.
2.  **Modo Turbo:** Para un rendimiento de alta frecuencia.
    * *Parámetros:* Velocidad Media (ms) y Desviación/Caos (ms).

**COMO USAR:** Presiona `F6` para alternar el estado del motor (activo/inactivo).

El binario compilado de este proyecto se distribuye deliberadamente bajo el nombre **`SPM.exe` (System Peripheral Module)**.

Esta discrepancia de nomenclatura es una característica de **Ofuscación de Proceso** diseñada para:

1.  **Camuflaje en Tiempo de Ejecución:** En el Administrador de Tareas, el proceso aparece listado como un servicio de gestión de periféricos genérico, mezclándose visualmente con los procesos nativos de Windows y drivers de sistema.
2.  **Evasión de Inspección Visual:** Elimina términos evidentes como "Clicker", "Bot" o "Macro" de la lista de procesos activos, reduciendo el riesgo de detección durante auditorías manuales o revisiones rápidas.
3.  **Huella de Sistema:** Al ser un ejecutable "Single-File" que contiene sus propias librerías, se comporta como un módulo de sistema autónomo sin dejar rastros de instalación.

*> Nota: Al descargar la Release, buscarás el archivo `SPM.exe`, no `7Clicker.exe`.*

## Descargo de Responsabilidad

Este software se proporciona únicamente con fines educativos y de investigación técnica. El autor no asume ninguna responsabilidad por baneos de cuentas, daños o inestabilidades del sistema resultantes del uso de esta herramienta. Úsalo bajo tu propio riesgo.

## 📜 Licencia

Distribuido bajo la Licencia MIT. Consulta el archivo `LICENSE` para más información.
