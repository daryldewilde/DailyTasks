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

Le projet se trouve dans le dossier `TaskManagementApp` et est implémenté entièrement en C# (sans vues XAML).

```text
TaskManagementApp/
├── App.cs
├── MauiProgram.cs
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
└── Resources/
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

### Prérequis

- [.NET 9.0 SDK](https://dotnet.microsoft.com/)
- Workload .NET MAUI installé
- Visual Studio / Visual Studio Code avec support MAUI
- SDK / émulateur Android (pour Android) et/ou environnement Windows

### Cloner et lancer

```bash
git clone https://github.com/daryldewilde/TaskManager.git
cd TaskManager/TaskManagementApp

dotnet restore
dotnet build
```

Exécuter sur Android (exemple) :

```bash
dotnet build -t:Run -f net9.0-android
```

Ou utiliser le bouton **Run/Debug** de l’IDE et sélectionner la cible (émulateur Android, appareil réel ou Windows).

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

## 📚 Références

- [Documentation .NET MAUI](https://learn.microsoft.com/dotnet/maui)  
- [Documentation SQLite](https://www.sqlite.org/docs.html)  
- [Guidelines Material Design](https://material.io/design)
