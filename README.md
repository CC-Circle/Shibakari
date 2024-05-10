<div id="top"></div>

## 使用技術一覧
![6d1df49565a2ad20ffa8386f1465ba52039133e3-1920x1080](https://github.com/CC-Circle/Shibakari/assets/115053448/4a594a7e-4828-4f9d-8e98-7f218d7c3702)
![Arduino_Logo svg](https://github.com/CC-Circle/Shibakari/assets/115053448/0df384ff-b5ca-45a8-ba9b-e0d66246d648)
![blender_logo_socket](https://github.com/CC-Circle/Shibakari/assets/115053448/1165d3e5-abdc-4807-bf99-ca6609505cbc)


## 目次

- [使用技術一覧](#使用技術一覧)
- [目次](#目次)
- [プロジェクト名](#プロジェクト名)
- [プロジェクトについて](#プロジェクトについて)
- [環境](#環境)
- [GitHubの運用方法について](#githubの運用方法について)
- [ディレクトリ構成](#ディレクトリ構成)
- [開発環境構築](#開発環境構築)
- [コミット、プルリクエスト、issue](#コミットプルリクエストissue)
- [トラブルシューティング](#トラブルシューティング)
- [その他参考記事](#その他参考記事)

## プロジェクト名

芝刈り

## プロジェクトについて

「芝刈り機をブンブン振り回して，一番遠くまで行こう！！」

  <p align="left">
    <br />
    <!-- プロジェクト詳細のリンク -->
    <a href="https://scrapbox.io/ait-ccc/%F0%9F%8F%83%E8%8A%9D%E5%88%88%E3%82%8A%E4%BC%81%E7%94%BB%E6%9B%B8"><strong>プロジェクト詳細 »</strong></a>
    <br />
    <br />

<p align="right">(<a href="#top">トップへ</a>)</p>

## 環境
<a href="https://github.com/CC-Circle/Shibakari/blob/main/ProjectSettings/ProjectVersion.txt">UnityのProjectVersion
</a>

## GitHubの運用方法について
GitHubフローを使用します．
詳しくは(https://docs.github.com/ja/get-started/using-github/github-flow)を参照してください．

<p align="right">(<a href="#top">トップへ</a>)</p>

## ディレクトリ構成
<!-- tree -L 2 "./" > "./"/tree.md -->

```md
> tree -L 2 "./"
./
├── Assembly-CSharp.csproj
├── Assets
│   ├── Materials
│   ├── Materials.meta
│   ├── Prefabs
│   ├── Prefabs.meta
│   ├── Scenes
│   ├── Scenes.meta
│   ├── Scripts
│   └── Scripts.meta
├── Library
│   ├── APIUpdater
│   ├── AnnotationManager
│   ├── ArtifactDB
│   ├── ArtifactDB-lock
│   ├── Artifacts
│   ├── Bee
│   ├── BuildPlayer.prefs
│   ├── BuildSettings.asset
│   ├── EditorOnlyScriptingSettings.json
│   ├── EditorOnlyVirtualTextureState.json
│   ├── EditorSnapSettings.asset
│   ├── EditorUserBuildSettings.asset
│   ├── InspectorExpandedItems.asset
│   ├── LastSceneManagerSetup.txt
│   ├── LibraryFormatVersion.txt
│   ├── MonoManager.asset
│   ├── PackageCache
│   ├── PackageManager
│   ├── SceneVisibilityState.asset
│   ├── ScriptAssemblies
│   ├── ScriptMapper
│   ├── Search
│   ├── ShaderCache
│   ├── ShaderCache.db
│   ├── SourceAssetDB
│   ├── SourceAssetDB-lock
│   ├── SpriteAtlasDatabase.asset
│   ├── StateCache
│   ├── Style.catalog
│   ├── TempArtifacts
│   ├── expandedItems
│   └── ilpp.pid
├── Logs
│   ├── AssetImportWorker0.log
│   ├── AssetImportWorker1.log
│   ├── Packages-Update.log
│   ├── shadercompiler-AssetImportWorker0.log
│   ├── shadercompiler-UnityShaderCompiler0.log
│   ├── shadercompiler-UnityShaderCompiler1.log
│   ├── shadercompiler-UnityShaderCompiler2.log
│   ├── shadercompiler-UnityShaderCompiler3.log
│   ├── shadercompiler-UnityShaderCompiler4.log
│   ├── shadercompiler-UnityShaderCompiler5.log
│   └── shadercompiler-UnityShaderCompiler6.log
├── Packages
│   ├── manifest.json
│   └── packages-lock.json
├── ProjectSettings
│   ├── AudioManager.asset
│   ├── ClusterInputManager.asset
│   ├── DynamicsManager.asset
│   ├── EditorBuildSettings.asset
│   ├── EditorSettings.asset
│   ├── GraphicsSettings.asset
│   ├── InputManager.asset
│   ├── MemorySettings.asset
│   ├── NavMeshAreas.asset
│   ├── PackageManagerSettings.asset
│   ├── Packages
│   ├── Physics2DSettings.asset
│   ├── PresetManager.asset
│   ├── ProjectSettings.asset
│   ├── ProjectVersion.txt
│   ├── QualitySettings.asset
│   ├── SceneTemplateSettings.json
│   ├── TagManager.asset
│   ├── TimeManager.asset
│   ├── UnityConnectSettings.asset
│   ├── VFXManager.asset
│   ├── VersionControlSettings.asset
│   └── XRSettings.asset
├── README.md
├── UserSettings
│   ├── EditorUserSettings.asset
│   ├── Layouts
│   ├── Search.index
│   └── Search.settings
├── obj
│   └── Debug
└── shibakari.sln

25 directories, 67 files

```

<p align="right">(<a href="#top">トップへ</a>)</p>

## 開発環境構築

<!-- コンテナの作成方法、パッケージのインストール方法など、開発環境構築に必要な情報を記載 -->

<p align="right">(<a href="#top">トップへ</a>)</p>

## コミット、プルリクエスト、issue
以下に従う
(https://github.com/CC-Circle/github-practice/blob/main/new_CONTRIBUTING.md)

<p align="right">(<a href="#top">トップへ</a>)</p>

## トラブルシューティング

<p align="right">(<a href="#top">トップへ</a>)</p>

## その他参考記事
【Mac】ターミナル（zsh）でtreeコマンドを使う方法

https://zenn.dev/harpseal/articles/ba01ec676e0137

<p align="right">(<a href="#top">トップへ</a>)</p>

