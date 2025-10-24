# Android Build Fix for Unity

## Problem
The Android build was failing due to Gradle being unable to download dependencies from JCenter repository, which has been deprecated and is no longer reliable.

## Solution Applied
1. **Updated Repository Sources**: Replaced `jcenter()` with more reliable repositories:
   - `mavenCentral()` - Primary Maven repository
   - `maven { url "https://repo1.maven.org/maven2/" }` - Maven Central mirror
   - `maven { url "https://maven.google.com" }` - Google's Maven repository

2. **Added Gradle Properties**: Created `gradleTemplate.properties` with:
   - Increased timeout settings for network operations
   - Memory optimization settings
   - Android build optimizations

## Files Modified
- `Assets/Plugins/Android/baseProjectTemplate.gradle`
- `Assets/Plugins/Android/baseProjectTemplate.gradle.DISABLED`
- `Assets/Plugins/Android/gradleTemplate.properties` (new file)

## Additional Recommendations

### 1. Clear Gradle Cache
If you still encounter issues, try clearing the Gradle cache:
```bash
# Delete the .gradle folder in your project
rm -rf Library/Bee/Android/Prj/Mono2x/Gradle/.gradle
```

### 2. Unity Build Settings
Make sure your Unity build settings are configured properly:
- Target API Level: Set to a stable version (e.g., API 30 or 31)
- Minimum API Level: Keep at 22 or higher
- Build System: Use Gradle (not Internal)

### 3. Network Issues
If you're behind a corporate firewall or have network restrictions:
- Configure proxy settings in Unity's Gradle settings
- Consider using a VPN if repositories are blocked

### 4. Alternative Solutions
If the problem persists:
1. Try building with "Development Build" unchecked
2. Use "Export Project" instead of "Build APK" to debug Gradle issues
3. Check Unity Console for any additional error messages

## Testing the Fix
1. Clean your project: `Assets > Reimport All`
2. Try building for Android again
3. If successful, the build should complete without timeout errors

## Notes
- The Library folder contains generated files that Unity recreates, so changes there are temporary
- The template files in Assets/Plugins/Android are the source templates Unity uses
- Always backup your project before making changes