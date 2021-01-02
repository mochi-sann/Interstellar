# Specification Document

~~仕様書っていうか割と適当に考えまとめる用のやつ~~

## Input周り

`IInputProvider` : 入力のObservableを返す

|関数|挙動|
|:---|:----|
|StartDragAsObservable()|押された瞬間その位置を通知する|
|EndDragStreamAsObservable()|指が離れた瞬間その位置を通知する|
|DragStreamAsObservable(); |押されてから離れるまで指の位置を通知する|

### 共通の挙動

Updateで受け取ったインプットをそのまま流す

`PlayerMover` などは受けとったObservableをFixedUpdateのタイミングに変換しなければいけない

## planetの自動生成関連

`Planet` : 惑星オブジェクトそのものを表す。ゲームオブジェクトと位置、大きさを持つ

`Cell` : 座標の変数 `min` と `max` を持ち、その範囲を表す。

`CellChunk` : `Cell` を一定範囲で纏めたもの。チャンク座標を `Vector2Int` で持つ

`GenerateSetting`
|||
|:---|:----|
|CellSize:float|セルの`min`から`max`までのサイズ|
|chunkCellRowCount:int|1チャンクの行のセルの数|
|chunkCellColumnCount:int|1チャンクの行のセルの数|

### 生成の流れ

`Player` プレイヤーの位置を監視して規定値以上の場所に行ったらその方向をPlanetGeneratorに伝える

`PlanetPosition` Playerが位置を元に**上下・左右・斜め**の8方向から `PlanetGenerator.Generate(Dir)` を呼ぶ
