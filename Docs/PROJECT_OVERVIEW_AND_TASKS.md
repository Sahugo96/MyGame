# Анализ проекта и перечень возможных задач

> Служебный документ (ветка `cline/gm5bs12m`), не влияет на сборку Unity.

## 1. Что это за проект

**Unity 6.3 (6000.3.19f1) — URP Empty Template**, переименованный в собственный проект.

Ключевые факты:

| Параметр | Значение |
|---|---|
| Ремоут | `https://github.com/Sahugo96/MyGame.git` |
| Ветка по умолчанию | `main` (1 коммит: `first commit`) |
| Версия Unity | `6000.3.19f1` (ревизия `7689f4515d75`) |
| Render pipeline | Universal RP `17.3.0` (PC/Mobile RP-ассеты + рендереры, DefaultVolumeProfile, URP Global Settings) |
| Input | Новый Input System `1.19.0` (`activeInputHandler: 1` — только Input System) |
| Company / Product | `DefaultCompany` / `My project` (не переименовано, bundleVersion `0.1.0`) |
| Pиксельная цель | `defaultScreenOrientation: 4`, 1024×768 по умолчанию |
| Ассеты | `SampleScene.unity` (Main Camera, Directional Light, Global Volume), `InputSystem_Actions.inputactions` (Player/UI), URP Settings, TutorialInfo (Readme) |
| Пакеты | AI Navigation 2.0.13, Test Framework 1.6.0, Timeline 1.8.12, uGUI 2.0.0, Visual Scripting 1.9.11, Multiplayer Center 1.0.1, Rider/VS IDE, Collab |
| Git LFS | включён в `.gitattributes` (png/jpg/psd/fbx/wav/ogg/mp3/exr), но `git-lfs` в песочнице не установлен |
| Build scenes | только `Assets/Scenes/SampleScene.unity` |

Стартовый шаблон, в котором ещё не написано игровой логики: собственных скриптов нет, кроме демонстрационного `TutorialInfo/Scripts/Readme.cs` + `ReadmeEditor.cs`.

## 2. Ограничения среды

- Unity Editor, `dotnet`/`mono`/`msbuild`, `git-lfs` в песочнице **отсутствуют** → нет компиляции, запуска тестов PlayMode/EditMode, билдов и реального LFS push.
- Работа ведётся со текстовыми файлами: C#, `.unity`/`.prefab`/`.asset` (YAML), `manifest.json`, ProjectSettings.
- Push выполняется с `git push --no-verify` (обходим LFS-хуки).

## 3. Что я могу делать / решать

### Код и геймплей
- Писать/рефакторить C#-скрипты: MonoBehaviour, ScriptableObject, UI (uGUI/UI Toolkit), системы на `Update`/корутинах, Job System/Burst при подключении пакетов.
- Проектировать архитектуру: игровой цикл, state machine, сервисы/DI, события, пулы объектов, save/load (JSON/PlayerPrefs), конфиги (ScriptableObject).
- Игровые подсистемы: персонаж и управление, камера (Cinemachine/своя), инвентарь, диалоги, квесты, ИИ на NavMesh, генерация уровней, физика/коллизии, анимация и Animator-контроллеры, Timeline-катсцены, звук/AudioMixer, партиклы/VFX, шейдеры и SHADER Graph (текстом), оптимизация (профайлинг-ориентированные правки, батчинг, LOD, Addressables).

### Настройка проекта и графика
- URP: качество, renderer features, post-processing (Volume Profile), материалы, lightmap-настройки, настройки платформ.
- Настройки проекта: теги/слои, физика (Physics/Physics2D), графика, качество, ввод, build settings, сцены, Player Settings, иконки, версии.
- Input System: `.inputactions` (action maps, bindings, control schemes), `InputActionAsset`, генерация C#-обёрток, поддержка геймпада/тача.

### Ассеты и данные (текстово)
- Правка/cоздание сцен и префабов вручную (YAML + корректные GUID/`.meta`), балансировка ассетов, настройка компонентов.
- Написание и валидация `.meta`, GUID-ссылок, устранение «missing script/reference».

### QA и качество
- Unit-тесты (Test Framework/EditMode/PlayMode) — написание кода тестов, статическая проверка логики.
- Ревью кода, поиск багов, гонок, утечек, нулевых ссылок, соответствия стилю/линтерам.
- Разбор логов/стектрейсов, диагностика по описанию симптомов.

### Инженерные/процессные задачи
- Git/GitHub: ветки, коммиты, `gh pr create`, ревью PR, `gh issue`, разбор диффов, `.gitignore`/`.gitattributes`, помощь с LFS.
- CI: написания workflow (GameCI/unity-builder, линт, тесты, сборка), Dockerfile для билдов, кэш Library.
- Документация: README, гайды, ADR, описание архитектуры, инструкции по сборке.
- Скрипты автоматизации (Editor-скрипты, batchmode задачи, утилиты для ассетов).

### Чего сделать нельзя
- Запустить Unity Editor, собрать билд, выполнить PlayMode-тест или сделать скриншот игры внутри песочницы — возможна только подготовка кода/конфигов и проверка логики «на бумаге».
- Загрузить бинарные ассеты (модели/текстуры/аудио) и корректно работать с LFS в этой среде.
