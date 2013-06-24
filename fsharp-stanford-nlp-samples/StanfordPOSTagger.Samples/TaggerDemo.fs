module TaggerDemo

open java.io
open java.util

open edu.stanford.nlp.ling
open edu.stanford.nlp.tagger.maxent;

open IKVM.FSharp

let model = @"..\..\..\..\StanfordNLPLibraries\stanford-postagger\models\wsj-0-18-bidirectional-nodistsim.tagger"

let tagReader (reader:Reader) = 
    let tagger = MaxentTagger(model)
    MaxentTagger.tokenizeText(reader).iterator()
    |> Collections.toSeq
    |> Seq.iter (fun sentence ->
            let tSentence = tagger.tagSentence(sentence :?> List)
            printfn "%O" (Sentence.listToString(tSentence, false))
        )

let tagFile (fileName:string) = 
    tagReader (new BufferedReader(new FileReader(fileName)))

let tagText (text:string) =
    tagReader (new StringReader(text))