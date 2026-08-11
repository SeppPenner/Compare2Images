# Project rules for Claude

## What this is

Compare2Images is a small Windows Forms application that compares two image files pixel by pixel
and shows a difference image: white where both images have the same color, red where they differ.
It is a desktop program, **not** a library and **not** a NuGet package: no `GeneratePackageOnBuild`,
no push script. It ships as an Inno Setup installer that is committed into this repository.

One solution `src/Compare2Images.sln` with exactly one project:

- `src/Compare2Images/Compare2Images.csproj`, `OutputType` `WinExe`, `UseWindowsForms`,
  `ApplicationIcon` `Compare2Images.ico`, `RuntimeIdentifiers` `win-x64`. The only package
  reference is `GitVersion.MsBuild`.

Layout inside `src/Compare2Images`:

- `Program.cs`: `[STAThread] Main`, enables visual styles and runs the `Main` form. Nothing else.
- `Main.cs`: the whole application logic. `LoadTitleAndDescription` writes product name and version
  into the window title, `ButtonFirstFileClick` and `ButtonSecondFileClick` open a file and show
  it, `ButtonGoClick` runs the comparison. The private helpers do one thing each, keep new logic in
  that shape.
- `Main.Designer.cs` plus `Main.resx`: designer generated form layout and the button images.
- `GlobalUsings.cs`: exists, but is empty apart from the `#pragma warning disable IDE0065` pair.
- `License.txt`: copied to the output directory with `CopyToOutputDirectory=Always`, the installer
  shows it as the license page.
- `Compare2Images.ico`, `dots14x10.bmp`, `face1.bmp`, `face2.bmp`.

`Setup` holds the installer: `Compare2Images-Setup.iss` (Inno Setup script),
`build-setup-files.bat` (cleans `bin` and `obj`, publishes, deletes the `*.pdb`) and the committed
`Compare2Images-Setup.exe`. The batch file does **not** compile the setup, `ISCC.exe` is run
separately.

Repository root: `README.md` (uppercase, the only user documentation), `Changelog.md`,
`License.txt` (MIT), `Screenshot.PNG` and `.gitattributes`. There is no `Updating.md`, no
`HowToUse.md`, no `.github` folder and no test project.

## Build

```powershell
dotnet build src/Compare2Images.sln -c Release
```

- Single target framework `net9.0-windows`, no multi-targeting. `RuntimeIdentifiers` is `win-x64`.
- All build properties live directly in `Compare2Images.csproj`. There is **no**
  `Directory.Build.props` in this repository.
- `TreatWarningsAsErrors` is enabled, so every warning breaks the build, NuGet warnings (`NU****`)
  from restore included. A clean build reports zero warnings, keep it that way.
- `NU1803` (HTTP source usage during restore) is the one warning suppressed via `NoWarn`. Fix
  warnings instead of extending that list. `NuGetAudit` and `NuGetAuditMode=all` are on, so a
  vulnerable transitive package fails the build too.
- Versions come from GitVersion.MsBuild out of the git tags, for example `1.0.8-1` for the first
  commit after tag `1.0.7`. Never edit a version property or an assembly version by hand.
- Restore needs nuget.org. If a private feed is configured globally on the machine and answers 404
  for public packages, restore fails with `NU1301`. Then build with an explicit source:
  `dotnet build src/Compare2Images.sln --source https://api.nuget.org/v3/index.json`.
- **There are no tests.** `dotnet test` finds no test project. A behaviour change is verified by
  running the application: publish it, start it, open two images and press `Go`.
  `src/Compare2Images/face1.bmp` and `face2.bmp` are two 32x32 images that differ in a few pixels
  and are the quickest way to see a red difference image. Never claim a run happened without
  running it.

## Code conventions

Follow the surrounding code, it is consistent in every hand written file:

- File header comment block with `<copyright file="..." company="Hämmer Electronics">` and a
  `<summary>`, then the file-scoped namespace.
- XML doc comments on every type and every member, private members and event handlers included, no
  exceptions. Event handlers document `<param name="sender">The sender.</param>` and
  `<param name="e">The event args.</param>`.
- `Nullable`, `ImplicitUsings` and `LangVersion latest` are enabled.
- New `using` directives go into `GlobalUsings.cs`, inside the existing
  `#pragma warning disable IDE0065` block, never at the top of a file. The editorconfig requires
  usings inside the namespace (`csharp_using_directive_placement=inside_namespace:warning`), which
  global usings cannot satisfy, that is what the pragma is for. Do not add other pragmas. The
  comment text in that block is German because Visual Studio generated it, leave it alone.
- Fields, properties, methods and events are always accessed with `this.` qualification
  (`dotnet_style_qualification_for_*` at severity `warning`).
- `src/.editorconfig` also enforces braces everywhere, no multiple blank lines, four spaces, CRLF,
  UTF-8, file scoped namespaces, `System` usings sorted first and `IDE0005` as warning. Analyzer
  warnings are fixed, not silenced.

## Known quirks

Do not silently "clean up" these, they are existing behaviour:

- **`GlobalUsings.cs` is empty.** It contains the `#pragma warning disable IDE0065` line and the
  matching `restore` line and nothing in between. Everything the code needs comes from
  `ImplicitUsings` and the Windows Forms SDK, including `System.Drawing` and
  `System.Windows.Forms`. The empty file is the documented place for the first real global using,
  do not delete it.
- **`Main.Designer.cs` is generated code.** It uses a block-scoped namespace, no `this.` on
  `components` and its own bracing style, all of which contradicts the editorconfig. Designer files
  are exempt from the IDE analyzers, which is why the build stays clean. Do not reformat it by
  hand, Visual Studio would write it back.
- **The comparison is `GetPixel` and `SetPixel` in a nested loop.** That is one managed call per
  pixel and gets slow for large images, roughly a second per megapixel. It is kept because it is
  what the referenced blog article shows and it is the readable version. `LockBits` would be the
  fix if it ever matters, not a micro optimization of the loop.
- **Only the overlapping area is compared.** The difference image has the size of the smaller
  image. Different dimensions alone already mean "different", that check happens after the loop.
- **`GetPixel` works on indexed bitmaps, `SetPixel` does not.** `dots14x10.bmp` is
  `Format8bppIndexed`, and reading it works. The result bitmap is created with
  `new Bitmap(width, height)`, which is `Format32bppArgb`, so `SetPixel` is safe. Keep it that way.
- **The three bitmaps in the project folder are sample data, not build input.** `dots14x10.bmp`,
  `face1.bmp` and `face2.bmp` have no `CopyToOutputDirectory` and are not embedded, they are simply
  tracked next to the code so that there is something to compare. Only `License.txt` is copied to
  the output.
- **The result texts are hardcoded English.** `"The images are identical"` and
  `"The images are different"` live directly in `Main.cs`. Unlike the sibling repositories this
  project has no language manager and no `languages` folder, so do not introduce `GetWord` calls
  here.
- **The installer is tracked although `.gitignore` ignores `*.exe`.** `Setup/Compare2Images-Setup.exe`
  is in the repository and every release adds a new copy of it to the history. It has to be staged
  with `git add -f`.
- **AppVeyor badge without CI in the repository.** `README.md` links an AppVeyor build that is
  configured outside of this repository. There is no pipeline file here.
- **`src/Compare2Images.sln.DotSettings`** is tracked and holds nothing but a ReSharper user
  dictionary with the single word `H_00E4mmer`. Leave it alone.
- **`.gitattributes` sets `* text=auto`** and every rule of the Visual Studio template below it is
  commented out. The tracked `*.bmp`, `*.ico`, `*.PNG` and `*.exe` files are recognized as binary by
  git's own heuristic. Any file where that heuristic could go wrong needs its own explicit rule.

## Releasing

1. Make the change.
2. Add an entry at the top of `Changelog.md` in the existing format:
   `* **Version 1.0.8.0 (2026-08-11)** : Short description.`
3. Set `MyAppVersion` in `Setup/Compare2Images-Setup.iss` to the same four part version.
4. Commit that.
5. Tag the commit with the plain version number, no `v` prefix (`1.0.8`, `1.0.7`, ...). The existing
   tags are lightweight tags, create new ones the same way.
6. Only **after** the tag, build the setup files: run `Setup/build-setup-files.bat`, then run
   `ISCC.exe` on `Setup/Compare2Images-Setup.iss`. GitVersion reads the tag, so a build before the
   tag would burn a prerelease version such as `1.0.8-3+Branch.master.Sha...` into the shipped
   executable. The history shows the same order: tag `1.0.7` sits on `ccb6880`, the setup commit
   `53329d2` comes after it.
7. Commit the new `Setup/Compare2Images-Setup.exe` with `git add -f`, message `Updated setup.`.
8. Push the commits and the tag.

The version in the `Changelog.md` has four parts (`1.0.8.0`), the tag has three (`1.0.8`).
GitVersion turns the tag into the assembly version and the window title shows it, which is the
quickest way to check that the released binary really came from the tagged commit.

## Git

- **Never amend a commit.** No `git commit --amend`, not for a typo in the message, not to add a
  forgotten file, not even when the commit is still local. Write a follow-up commit instead. The
  release versions come from tags on exact commits, an amended commit leaves its tag pointing at a
  commit that no longer exists in the branch.

## Writing style

- Commit messages are written **in English only**: short, precise subject line, explanatory body
  when needed.
- Code comments and comments in project files such as `.csproj` are **always English**, regardless
  of the language used in the conversation.
- **No em dashes or en dashes** (`—`, `–`), neither in prose, commit messages, code comments nor
  documentation. Use a regular hyphen, comma, colon, parentheses or a separate sentence.
- German texts (documentation, chat replies) always use real umlauts and ß, never ASCII
  transliterations such as `ae`, `oe`, `ue` or `ss`. Identifiers, file names and configuration keys
  stay unchanged where umlauts are technically undesirable.
