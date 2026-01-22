# 7Clicker

Herramienta de automatización de entrada de alta precisión diseñada para la simulación de comportamiento humano. A diferencia de los scripts de automatización estándar que utilizan retrasos estáticos, 7Clicker implementa algoritmos de aleatorización basados en distribución gaussiana y emulación de micro-movimientos en reposo para eludir los sistemas de detección heurística.

**Versión actual:** v1.0 (Nativo C# / WPF)

<img width="434" height="442" alt="{57BD8740-0EFA-4E8D-B294-70C07B9B24BB}" src="https://github.com/user-attachments/assets/6a6a5ce1-ad75-4e15-9c08-5331d0f7b22f" />


## ⚡ Características Principales

* **Motor de Distribución Gaussiana:** Los clics se generan utilizando curvas de probabilidad matemática (transformada de Box-Muller), eliminando los patrones estáticos predecibles.
* **Modo Fantasma (Human Idle):** Simula la deriva orgánica del ratón y micro-movimientos durante los periodos de espera. Incluye lógica de comportamiento errático (distracciones, variaciones en doble clic).
* **Arquitectura Sigilosa:** Se compila como `SPM.exe` (Service Performance Module). Se ejecuta como un proceso nativo independiente sin dependencias externas (núcleo .NET 10 integrado en el ejecutable).
* **Input a Nivel de Kernel:** Utiliza llamadas directas a `user32.dll` para una ejecución de baja latencia.

## 🛠️ Uso

La aplicación opera en dos modos a través de la interfaz:

1.  **Modo Fantasma (Predeterminado):** Para simulación de navegación errática y de baja frecuencia.
    * *Parámetros:* Tiempo de espera Mín/Máx (Segundos).
    * *Idle Jitter:* Habilita micro-movimientos aleatorios durante la inactividad.
2.  **Modo Turbo:** Para un rendimiento de alta frecuencia.
    * *Parámetros:* Velocidad Media (ms) y Desviación/Caos (ms).

**COMO USAR:** Presiona `F6` para alternar el estado del motor (activo/inactivo).

## ⚠️ Descargo de Responsabilidad

Este software se proporciona únicamente con fines educativos y de investigación técnica. El autor no asume ninguna responsabilidad por baneos de cuentas, daños o inestabilidades del sistema resultantes del uso de esta herramienta. Úsalo bajo tu propio riesgo.

## 📜 Licencia

Distribuido bajo la Licencia MIT. Consulta el archivo `LICENSE` para más información.
