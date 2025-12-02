# DailyTasks – Task Management App

DailyTasks est une application simple de gestion de tâches fonctionnant hors ligne, développée avec **.NET MAUI (.NET 9.0)** en **C# pur (sans XAML)**.  
Elle cible **Android et Windows** et est conçue pour être claire, rapide et facile à utiliser.

Ce projet est développé dans le cadre du **Master 2 Génie Logiciel – Atelier de Développement Mobile (.NET MAUI)** à l’**École Nationale Supérieure Polytechnique de Douala**.

---

## 📸 Captures d’écran

![Captures d’écran de l’application mobile DailyTasks](screenshots.png)

Cette image regroupe les principales vues de l’application : inscription, connexion, liste des tâches, ajout/édition de tâche, détails et paramètres (mode sombre).

---

## ✨ Fonctionnalités

- 🔐 **Authentification**
  - Inscription avec email et mot de passe.
  - Connexion pour accéder à sa liste de tâches personnelle.

- 📝 **Gestion des tâches**
  - Ajouter des tâches avec :
    - Titre
    - Description
    - Date d’échéance
    - Priorité
  - Modifier les tâches existantes.
  - Supprimer les tâches inutiles.
  - Marquer les tâches comme **terminées** ou **en cours**.

- 📊 **Filtrage & tri**
  - Affichage des tâches sous forme de liste claire.
  - Filtrer / trier par :
    - Date d’échéance
    - Priorité
    - Statut (terminée / en cours).

- 🌙 **Paramètres**
  - Page de paramètres dédiée.
  - **Mode sombre** pour plus de confort visuel et une meilleure autonomie.

- 📶 **Hors ligne**
  - Toutes les données sont stockées **localement** (pas de cloud, pas de connexion Internet requise).

---

## 🧱 Structure du projet

Le projet principal se trouve dans le dossier `TaskManagementApp` et est implémenté entièrement en C# (sans vues XAML).

```text
TaskManagementApp/
├── App.cs
├── MauiProgram.cs
├── Platforms/          // Configuration par plateforme (Android, Windows, etc.)
├── Models/
│   ├── Member.cs         // Modèle utilisateur (authentification)
│   └── TaskItem.cs       // Modèle tâche (titre, description, date, priorité, statut)
├── Services/
│   ├── LibraryService.cs // Données et état partagés entre les pages
│   └── TaskService.cs    // Logique métier des tâches : ajout, édition, suppression, filtrage, tri
├── Pages/
│   ├── RegisterPage.cs   // Écran d’inscription
│   ├── LoginPage.cs      // Écran de connexion
│   ├── MainPage.cs       // Écran principal (liste des tâches + actions)
│   ├── AddTaskPage.cs    // Ajout de tâche
│   ├── EditTaskPage.cs   // Modification de tâche
│   ├── TaskDetailPage.cs // Détails d’une tâche
│   └── SettingsPage.cs   // Paramètres (mode sombre, infos utilisateur)
└── Resources/            // Styles, images, etc.
```

---

## 🧠 Architecture & conception

- **Framework** : [.NET MAUI](https://learn.microsoft.com/dotnet/maui) sur **.NET 9.0**  
- **Langage** : C# (UI et logique)
- **UI** : composants MAUI déclarés en C# (aucun fichier XAML)
- **Données** :
  - Stockage local (aligné avec l’utilisation d’une base locale type SQLite).
  - Services (`LibraryService`, `TaskService`) centralisent les données et la logique.
- **Séparation des responsabilités** :
  - `Models` : structures de données (`Member`, `TaskItem`).
  - `Services` : logique applicative (authentification, tâches, filtrage/tri).
  - `Pages` : écrans de l’interface utilisateur, reliés directement en C#.

---

## 🚀 Prise en main

### 1. Prérequis généraux

Assure-toi d’avoir :

- [SDK .NET 9.0](https://dotnet.microsoft.com/)
- Workload **.NET MAUI** installé :

  ```bash
  dotnet workload install maui
  ```

- Un IDE compatible .NET MAUI, par exemple :
  - **Visual Studio 2022** (Windows) avec la charge de travail « Développement multiplateforme .NET MAUI »
  - ou **Visual Studio Code** avec l’extension C# et le SDK .NET MAUI configuré.

- Pour **Android** :
  - SDK Android + outils de build (installés via Visual Studio ou Android Studio).
  - Au moins un **émulateur Android** configuré (ou un appareil physique avec le mode développeur + débogage USB activé).

- Pour **Windows** :
  - Windows 10/11 avec la prise en charge des applications .NET MAUI (UWP/WinUI selon la configuration du projet).

---

### 2. Cloner le dépôt

```bash
git clone https://github.com/daryldewilde/DailyTasks.git
cd DailyTasks/TaskManagementApp
```

> Note : le dossier contenant le projet .NET MAUI est `TaskManagementApp`.

---

### 3. Restauration des dépendances

```bash
dotnet restore
```

---

### 4. Build du projet

```bash
dotnet build
```

Si le build échoue, vérifie :

- Que le **SDK .NET 9.0** est bien installé (`dotnet --list-sdks`).
- Que le **workload MAUI** est installé (`dotnet workload list`).
- Que les plateformes ciblées (Android, Windows) sont bien supportées sur ta machine.

---

### 5. Lancer l’application

#### 5.1. Depuis la ligne de commande

- **Android** :

  ```bash
dotnet build -t:Run -f net9.0-android
  ```

  Assure-toi qu’un émulateur Android est démarré ou qu’un appareil est connecté.

- **Windows** (si cible Windows activée dans le projet) :

  ```bash
dotnet build -t:Run -f net9.0-windows10.0.19041.0
  ```

  L’identifiant de la version Windows peut varier selon la configuration du projet (`TargetFramework`).

#### 5.2. Depuis l’IDE (Visual Studio recommandé)

1. Ouvre la solution/projet depuis le dossier `TaskManagementApp` :

   - Fichier ➜ Ouvrir ➜ Projet/Solution ➜ sélectionne le fichier `.csproj` ou `.sln` de `TaskManagementApp`.

2. Choisis la **configuration** :
   - `Debug` (pour le développement)
   - `Release` (pour les tests finaux)

3. Choisis la **cible d’exécution** dans la barre d’outils :
   - Un émulateur Android (par ex. `Pixel_5_API_34`)
   - Un appareil Android physique
   - `Windows Machine` (si support Windows activé)

4. Clique sur **Run / Debug** (bouton ▶).

---

## 🔐 Authentification & tâches (vue d’ensemble)

- **Authentification**
  - Inscription et connexion via email + mot de passe.
  - Validation des entrées pour éviter les données invalides.
  - Gestion sécurisée des identifiants (mot de passe non stocké en clair côté logique).

- **Tâches**
  - Chaque tâche est représentée par `TaskItem` :
    - Titre, description, date d’échéance, priorité, statut (terminée/en cours).
  - `TaskService` gère :
    - Création, mise à jour, suppression de tâches.
    - Filtrage par statut.
    - Tri / filtrage par date et priorité.

- **État partagé**
  - `LibraryService` est utilisé pour partager les données utilisateurs et tâches entre les différentes pages afin que :
    - Register/Login, MainPage, Add/Edit, Détails et Paramètres restent synchronisés.
    - La navigation ne perde pas le contexte de l’utilisateur connecté.

---

## 🧪 Tests & débogage

- Utilise le mode **Debug** pour :
  - Placer des points d’arrêt dans les `Pages`, `Services` et `Models`.
  - Vérifier le cycle de vie des pages MAUI (navigation, apparition/disparition des vues).
- Pour vérifier la gestion hors ligne, coupe la connexion réseau de l’appareil/émulateur et assure-toi que :
  - Les tâches restent accessibles.
  - Les opérations de création/édition/suppression continuent de fonctionner.

---

## 📚 Références

- [Documentation .NET MAUI](https://learn.microsoft.com/dotnet/maui)  
- [Documentation SQLite](https://www.sqlite.org/docs.html)  
- [Guidelines Material Design](https://material.io/design)