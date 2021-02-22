<p align="center"">
    <h1 align="center">Winhooks</h1>
    <p align="center">
        <img src="https://img.shields.io/badge/made%20with-C%23-blue?style=plastic">
        <img src="https://img.shields.io/badge/license-MIT-green?style=plastic">
        <img src="https://img.shields.io/badge/open%20source-red?style=plastic">
        <img src="https://img.shields.io/badge/suggestions-welcome-green?style=plastic">
        <img src="https://img.shields.io/github/last-commit/augus99/winhooks?style=plastic">
        <img src="https://img.shields.io/github/commit-activity/y/augus99/winhooks?style=plastic">
    </p>
</p>

## Description
This library focuses on the monitoring of keyboard and mouse inputs.

## Build
To build the `dll` you will need dotnet installed on your computer, then type the following lines on your preferred terminal
```console
augus99@home:~/Desktop $ git clone https://github.com/augus99/winhooks.git
augus99@home:~/Desktop $ cd winhooks
augus99@home:~/Desktop/winhooks $ dotnet build
```

## Example
The following example will print every key pressed to the console
```cs
new KeyboardHook((sender, args) => {
    Console.WriteLine(args.KeyPressed);
});
```