# PRD: BibleShow Migration to .NET 8 Cross-Platform

## Introduction/Overview
This PRD outlines the migration strategy for transforming BibleShow from a Windows-only .NET Framework 4.5.2+ application to a modern, cross-platform .NET 8 application. This migration represents Phase 1 of the BibleShow Next-Gen project, focusing on establishing a solid foundation for future features while maintaining existing functionality.

## Goals
1. Successfully migrate the BibleShow codebase from .NET Framework 4.5.2+ to .NET 8
2. Enable cross-platform support for Windows, macOS, and Linux
3. Maintain feature parity with existing core functionality
4. Establish API-first architecture for future extensibility
5. Implement secure offline-first functionality
6. Set up a modern, maintainable project structure

## User Stories
1. As a church tech volunteer, I want to run BibleShow on my Mac, so I don't need a separate Windows machine for presentations
2. As a developer, I want to work with a modern .NET codebase, so I can leverage current best practices and tools
3. As a user, I want the same fast verse display performance I had in the classic version
4. As a system administrator, I want to run BibleShow on our Linux-based presentation system
5. As an offline user, I want BibleShow to work without internet connectivity
6. As a power user, I want all existing keyboard shortcuts and hotkeys to work the same way

## Functional Requirements

### 1. Core Migration Requirements
1.1. Port all existing BibleShow functionality to .NET 8
1.2. Maintain support for all 180+ Bible modules
1.3. Preserve support for 60+ languages
1.4. Ensure XML+PNG export functionality works identically
1.5. Maintain or improve verse display performance
1.6. Support all existing keyboard shortcuts and global hotkeys

### 2. Cross-Platform Infrastructure
2.1. Create platform-agnostic UI layer using .NET MAUI
2.2. Implement platform-specific file system handling
2.3. Support platform-native window management
2.4. Handle platform-specific paths and configurations
2.5. Implement cross-platform installation and update mechanism

### 3. API Architecture
3.1. Design RESTful API structure
3.2. Implement JWT authentication system
3.3. Create secure local storage mechanism
3.4. Design offline-first data synchronization
3.5. Set up API documentation system

### 4. Data Migration
4.1. Convert existing data structures to cross-platform format
4.2. Implement Bible module compatibility layer
4.3. Create data migration tools for existing users
4.4. Ensure backward compatibility with existing file formats

### 5. Development Infrastructure
5.1. Set up cross-platform CI/CD pipeline
5.2. Implement automated testing framework
5.3. Create development environment setup scripts
5.4. Establish logging and telemetry system
5.5. Set up error reporting mechanism

## Non-Goals
- Adding new features beyond existing functionality
- Changing the user interface design
- Implementing cloud synchronization (Phase 3)
- Adding voice recognition features (Phase 4)
- Modifying the NDI implementation (Phase 5)

## Technical Considerations
1. **Framework Selection**
   - .NET MAUI for cross-platform UI
   - ASP.NET Core for API layer
   - SQLite for local storage
   - Entity Framework Core for data access

2. **Migration Challenges**
   - Windows-specific API usage
   - COM interop dependencies
   - Global hotkey implementation
   - NDI implementation differences
   - File system access patterns

3. **Performance Requirements**
   - Verse display latency < 100ms
   - Application startup < 2 seconds
   - Memory usage < 200MB
   - Smooth scrolling and navigation

## Success Metrics
1. **Technical Metrics**
   - 100% feature parity with existing version
   - All automated tests passing
   - Performance benchmarks meeting or exceeding current version
   - Successful builds on all target platforms

2. **User Experience Metrics**
   - Zero regression in verse display speed
   - Identical keyboard shortcut behavior
   - File format compatibility
   - Successful migration of user settings

## Open Questions
1. How will we handle Windows-specific features on other platforms?
2. What is the strategy for testing NDI functionality cross-platform?
3. How do we ensure consistent font rendering across platforms?
4. What is the backup strategy for offline data?
5. How do we handle platform-specific installation requirements?