module JavaCollections

open java.util

let toSeq (iter:Iterator) =
    let rec loop (x:Iterator) = 
        seq { 
            yield x.next()
            if x.hasNext() then 
                yield! (loop x)
            }
    loop iter

let toArrayList seq =
    let list = ArrayList()
    seq |> Seq.iter (fun x -> list.Add(x))
    list