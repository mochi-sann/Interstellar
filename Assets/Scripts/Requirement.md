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

これらのストリームを使う側は必要に応じて`BatchFrame`や`WithLatestFrom`でFixedUpdateに変換する

## プレイヤーの移動(打ち上げ)

プレイヤーの移動はターン制のようになっている  
アイドル状態　→　打ち上げ　→　planetに刺さるorその他(未定)のアクション


`RocketLauncher`

## planetの自動生成関連

`Planet`: 惑星オブジェクトそのものを表す。ゲームオブジェクトと位置、大きさを持つ

`Cell`: 座標の変数 `min` と `max` を持ち、その範囲を表す。

`CellChunk`: `Cell` を一定範囲で纏めたもの。チャンク座標を `Vector2Int` で持つ

`GenerateSetting`

||||
|:---|:---|:---|
|float|CellSize|セルの`min`から`max`までのサイズ|
|int|chunkCellRowCount|1チャンクの行のセルの数|
|int|chunkCellColumnCount|1チャンクの行のセルの数|

### 生成の流れ
プレイヤーの位置を監視する

規定値以上の位置に行ったらその方向をPlanetGeneratorに伝える
