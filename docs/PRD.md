AthleteCareLite — Product Requirements Document (PRD)
Version 0.1 — Early Scaffold

1. Purpose
AthleteCareLite is a lightweight athlete wellness & performance tracking portal designed to demonstrate a modern ASP.NET Core + Blazor Static SSR architecture. It mirrors the workflow shape of SportsWareOnLine™ (profiles, daily entries, logs, documentation, dashboards) without touching medical compliance or PHI.

The app exists to showcase:

ASP.NET Core MVC patterns applied to Blazor Static SSR

Razor Components + server‑side rendering

EF Core + SQL Server

Tailwind/DaisyUI UI

Azure‑ready architecture

Clean, regenerable code suitable for multi‑agent orchestration

This PRD defines the initial feature set required for a functional demo application.

2. High‑Level Goals
Provide CRUD workflows for athlete‑related data.

Demonstrate server‑rendered Razor Components.

Show clean separation of Core, Infrastructure, and Web layers.

Provide a simple dashboard summarizing recent activity.

Keep scope intentionally small and buildable in phases.

3. Core Features
3.1 Athlete Profiles
Basic entity representing an athlete.

Fields

AthleteId (GUID)

Name

School

GraduationYear

PrimarySport

Capabilities

Create / Edit / Delete athlete profiles

List athletes

View athlete detail page with related wellness logs, training logs, and notes

3.2 Daily Wellness Check‑Ins
Athletes submit daily wellness metrics.

Fields

CheckInId (GUID)

AthleteId (FK)

Date

SleepHours (int)

SorenessLevel (1–10)

Mood (1–10)

ReadinessScore (1–10)

Capabilities

CRUD operations

Display recent check‑ins on athlete detail page

Display recent check‑ins on dashboard

3.3 Training Session Logs
Coaches or athletes record training sessions.

Fields

SessionId (GUID)

AthleteId (FK)

Date

Activity (string)

DurationMinutes (int)

Notes (string)

Capabilities

CRUD operations

Show recent training sessions on athlete detail page

Show recent training sessions on dashboard

3.4 Coach Notes
Simple documentation entries.

Fields

NoteId (GUID)

AthleteId (FK)

Date

NoteText

Capabilities

CRUD operations

Display notes on athlete detail page

3.5 Dashboard
A server‑rendered Razor Component summarizing:

Recent wellness check‑ins (last 7 days)

Recent training sessions (last 7 days)

Quick links to athlete profiles

This is intentionally minimal — just enough to demonstrate SSR + Blazor component composition.

4. Non‑Functional Requirements
4.1 Architecture
Clean architecture with separate Core, Infrastructure, Web, and Api projects.

EF Core + SQL Server.

Razor Components with Blazor Static SSR.

Tailwind CSS + DaisyUI (or Bootstrap fallback).

Azure‑ready configuration.

4.2 Coding Principles
Follow the Mandatory Coding Principles from the Ultralight Orchestration document:

Flat, explicit architecture

Regenerable files

Minimal coupling

Deterministic behavior

Clear naming

Structured logging

4.3 Deployment
Local development via SQL Server Express or localdb.

Azure App Service + Azure SQL for cloud deployment (later phase).

5. Out‑of‑Scope (for initial build)
Authentication / authorization

Role‑based access

Advanced reporting

Mobile UI

Notifications

Import/export

Multi‑tenant SaaS features

Medical or HIPAA‑related workflows

These may be added later as separate Orchestrator phases.

6. Initial Milestones
Milestone 1 — Scaffold
Create solution structure

Add Core models

Add DbContext + migrations

Add Infrastructure repositories

Add Web project with basic navigation

Add minimal CRUD pages for all entities

Milestone 2 — Dashboard
Add dashboard Razor Component

Add queries for recent check‑ins and training logs

Milestone 3 — Polish
Add Tailwind/DaisyUI styling

Add basic layout, header, footer

Add simple validation

7. Orchestration Integration
This PRD is the input for the Planner agent.
The Planner will convert this into:

Step‑by‑step plan

File assignments

Dependencies

Parallelizable phases

The Orchestrator will then execute those phases using Coder + Designer agents.

8. Version History
v0.1 — Initial PRD scaffold
