# BibleShow Next-Gen Desktop App - System Context

---

## Project Overview
Developing a next-generation cross-platform desktop application for BibleShow, a scripture presentation tool for churches and Christian organizations. The goal is to modernize the existing Windows-only .NET Framework application into a cross-platform, API-first ecosystem with cloud sync, mobile remote control, and AI voice recognition.

---

## Current State Analysis
- **Existing BibleShow**: Windows-only, .NET Framework 4.5.2+
- **Strengths**: Fast verse display, NDI output/input, XML+PNG exports, 180+ Bible modules, 60+ languages
- **Limitations**: No cross-platform support, no API, no mobile remote, limited extensibility
- **Integration**: Strong NDI support for vMix/OBS, keyboard shortcuts, global hotkeys

---

## Architecture Vision
- **Cross-Platform**: .NET 8 or Electron for Windows/macOS/Linux support
- **API-First**: REST backend with JWT auth, cloud sync for playlists/themes/settings
- **Voice Integration**: Cloud-based speech recognition (Azure/Google) with NLP for scripture lookup
- **Extensibility**: Local HTTP/WebSocket API for third-party control surfaces
- **Modern UI**: Clean, responsive interface preserving one-click verse display workflow

---

## Development Roadmap

### Phase 1: Foundation & Architecture
- Migration from .NET Framework to .NET 8 cross-platform
- API-first architecture design with REST backend
- Security model (JWT auth, local secure storage, offline graceful degradation)
- Cross-platform project structure setup

### Phase 2: Core UI/UX
- Modern responsive UI with panes: Live Control, Playlist Editor, Scripture Browser, Theme Manager, NDI Monitor
- Preserve one-click/hotkey verse display workflow
- Accessibility improvements (scalable fonts, RTL support, colorblind-safe themes)
- Dark mode and theme customization interface

### Phase 3: API & Integration Layer
- Local API endpoints for external control
- Cloud sync schema for playlists and themes
- Enhanced data models for themes & scripture content
- Integration with external APIs (API.Bible, Bible SDK)

### Phase 4: Voice Recognition Mesh
- Cloud-based recognition integration (Azure/Google)
- NLP intent/entity mapping for scripture lookup + controls
- Offline fallback for basics
- UI cues for listening/voice recognition state

### Phase 5: Live Production Enhancements
- Multi-channel NDI output
- WebSocket/HTTP hooks for control surfaces
- Plugin system architecture
- Validate workflows with vMix/OBS/ProPresenter

### Phase 6: Testing & Release Strategy
- Cross-platform testing matrix
- Performance benchmarks (startup time, verse display latency, API response times)
- Beta program for migrating from BibleShow Classic
- Update/rollback strategy with cloud-synced backups

---

## Product Development Rules (merged from create-prd.md)

### Generating PRDs
1. User gives feature idea → ask clarifiers before drafting.  
2. Clarifiers include: Problem/Goal, Target User, Core Functionality, User Stories, Acceptance Criteria, Non-goals, Data/UI needs, Edge Cases.  
3. PRD Format:  
   - Introduction/Overview  
   - Goals  
   - User Stories  
   - Functional Requirements (numbered)  
   - Non-Goals  
   - Design Considerations (optional)  
   - Technical Considerations (optional)  
   - Success Metrics  
   - Open Questions  
4. Audience: Junior developer, avoid jargon.  
5. Save file: `/tasks/prd-[feature].md`.  

---

## Task Generation Rules (merged from generate-tasks.md)

### From PRD → Task List
1. Point AI to a PRD.  
2. Analyze functional requirements + context.  
3. Assess current state of repo/components.  
4. Phase 1: Generate high-level **parent tasks** only. Pause & confirm with user before breaking down.  
5. Phase 2: Expand parent tasks into **sub-tasks**.  
6. Identify **Relevant Files** (to create/modify, with test files).  
7. Output Final Format:  

```markdown
## Relevant Files
- path/to/file.ts – description
- path/to/file.test.ts – description

## Tasks
- [ ] 1.0 Parent Task
  - [ ] 1.1 Subtask
  - [ ] 1.2 Subtask
- [ ] 2.0 Parent Task