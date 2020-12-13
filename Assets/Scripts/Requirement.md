# Specification Document

~~仕様書っていうか割と適当に考えまとめる用のやつ~~

# Input周り

## `IInputProvider` 
入力のObservableを返す

|関数|挙動|
|:---|:----|
|StartDragAsObservable()|押された瞬間その位置を通知する|
|EndDragStreamAsObservable()|指が離れた瞬間その位置を通知する|
|DragStreamAsObservable();|押されてから離れるまで指の位置を通知する|

### 共通の挙動
Updateで受け取ったインプットをそのまま流す

`PlayerMover`などは受けとったObservableをFixedUpdateのタイミングに変換しなきゃいけない