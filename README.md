# NuclearPlus

Provides advanced nuclear research to the game.

Currently alpha.

Currently provides:
* Fast breeder reactor
* Advanced reactor
* Many new products (uranyl nitrate, plutonium nitrate, nitric acid, ...)

More may come... please create an issue for any suggestions or bugs.

# How to install

> :warning: **You will need to start a new game to play this mod. This is a restriction of CoI.**

Download the latest release: https://github.com/NotoriousPyro/NuclearPlus/releases

1. From the downloaded zip, copy the contents of the `Mods` folder to your Captain of Industry `Mods` folder.

    By default, this is `Documents\Captain of Industry\Mods`. You can find out where exactly by running the following in PowerShell:
    ```powershell
    ((new-object -COM Shell.Application).Namespace(0x05).Self.Path + '\Captain of Industry\Mods')
    ```

2. Verify inside 'Mods' folder, each sub-folder has **a dll file with the same name as the folder**, it is fine if other DLLs are also present.

3. Enable the `Enable mods` options in the ingame settings.

4. Start a new game!

# How to use

## Basic setup
![Basic setup](docs/basicsetup.png)

## Research
Research is currently limited to a single item which unlocks everything, this may be changed later...
* **Advanced nuclear**: dependant on Nuclear reactor first being completed.
![Research: Advanced Nuclear](docs/research_advancednuclear.png)

## Recipes
* Incineration plant
![Recipes: ](docs/recipes_.png)
