
#r "FSharp.Data.dll"
open System.Net
open FSharp.Data
open FSharp.Data.JsonExtensions


type User = {id:int; first_name:string; last_name:string; username:string }

let getUser (value:JsonValue) =
    {id = (value?id.AsInteger()); first_name = (value?first_name.AsString());
     last_name = (value?id.AsString()); username = (value?id.AsString())}

type Chat = {id:int; ctype:string; title:string; username:string; first_name:string; last_name:string}

let getChat (value:JsonValue) =
    {id =  (value?id.AsInteger()); ctype =  (value?``type``.AsString()); title =  (value?title.AsString());
     username = (value?username.AsString()); first_name =  (value?first_name.AsString());
     last_name =  (value?last_name.AsString());}

type Audio = {file_id:string; duration:int; performer:string; title:string; mime_type:string; file_size:int}

let getAudio (value:JsonValue) =
    {file_id = (value?file_id.AsString()); duration = (value?duration.AsInteger());
     performer = (value?performer.AsString()); title = (value?ltitle.AsString());
     mime_type = (value?mime_type.AsString()); file_size = (value?file_size.AsInteger());}

type PhotoSize = {file_id:int; width:int; height:int; file_size:int}

let getPhotoSize (value:JsonValue) =
    {file_id = (value?file_id.AsInteger()); width = (value?width.AsInteger());
     height = (value?width.AsInteger()); file_size = (value?file_size.AsInteger());}

type Location = {longitude:decimal; latitude:decimal}

let getLocation (value:JsonValue) =
    {longitude = (value?longitude.AsDecimal()); latitude = (value?latitude.AsDecimal());}

type UserProfilePhotos = {total_count:int; photos:PhotoSize list}

let getUserProfilePhotos (value:JsonValue) =
    {total_count = (value?total_count.AsInteger());
     photos = [ for item in (value?photos) do yield getPhotoSize item ];}


type File = {file_id:string; file_size:int; file_path:string}

let getFile (value:JsonValue) =
    {file_id =  (value?file_id.AsString()); file_size = (value?file_size.AsInteger()); file_path = (value?file_path.AsString());}

type ReplyKeyboardMarkup = {keyboard:string list list; resize_keyboard:bool; one_time_keyboard:bool;
                            selective:bool}

let getReplyKeyboardMarkup (value:JsonValue) =
    {keyboard = [ for items in value?keyboard do yield [ for item in items do yield item.AsString()] ];
     resize_keyboard = (value?resize_keyboard.AsBoolean());
     one_time_keyboard = (value?one_time_keyboard.AsBoolean());
     selective = (value?selective.AsBoolean();)}

type ReplyKeyboardHide = {hide_keyboard:bool; selective:bool;}

let getReplyKeyboardHide (value:JsonValue) =
    {hide_keyboard = (value?hide_keyboard.AsBoolean()); selective = (value?selective.AsBoolean());}

type ForceReply = {force_reply:bool; selective:bool}

let getForceReply (value:JsonValue) =
    {force_reply = (value?force_reply.AsBoolean()); selective = (value?selective.AsBoolean());}

type InlineQuery = {id:string; from:User; query:string; offset:string}

let getInlineQuery (value:JsonValue) =
    {id = (value?id.AsString()); from = getUser (value?from); query = (value?query.AsString());
     offset = (value?offset.AsString());}

type AnswerInlineQuery = {inline_query_id:int; results:InlineQuery list; cache_time:int;
                          is_personal:bool; next_offset:string}

let getAnswerInlineQuery (value:JsonValue) =
    {inline_query_id = (value?inline_query_id.AsInteger());
     results = [ for item in (value?results) do yield getInlineQuery item];
     cache_time = (value?cache_time.AsInteger());
     is_personal = (value?is_personal.AsBoolean());
     next_offset = (value?next_offset.AsString());}

type InlineQueryResultArticle = {atype:string; id:string; title:string; message_text:string;
                                 parse_mode:string; disable_web_page_preview:bool; url:string;
                                 hide_url:string; description:string; thumb_url:string;
                                 thumb_width:string; thumb_height:string;}

let getInlineQueryResultArticle (value:JsonValue) =
    {}

type InlineQueryResultPhoto = {ptype:string; id:string; photo_url:string; photo_width:int; photo_height:int;
                               thumb_url:string; title:string; description:string; caption:string;
                               message_text:string; parse_mode:string; disable_web_page_preview:bool}
type InlineQueryResultGif = {gtype:string; id:string; gif_url:string; gif_width:int; gif_height:int;
                             thumb_url:string; title:string; caption:string; message_text:string;
                             parse_mode:string}
type InlineQueryResultMpeg4Gif = {mtype:string; id:string; mpeg4_url:string; mpeg4_width:string;
                                  mpeg4_height:string; thumb_url:string; title:string; caption:string;
                                  message_text:string; parse_mode:string}
type InlineQueryResultVideo = {vtype:string; id:string; video_url:string; mime_type:string; message_text:string;
                               parse_mode:string; disable_web_page_preview:string; video_width:int;
                               video_height:int; video_duration:int; thumb_url:string; title:string;
                               description:string}
type ChosenInlineResult = {result_id:string; from:User; query:string}


type Document = {file_id:int; thumb:PhotoSize; file_name:string; mime_type:string; file_size:int}
type Sticker = {file_id:int; width:int; height:int; thumb:PhotoSize; file_size:int}
type Video = {file_id:int; width:int; height:int; duration:int; thumb:PhotoSize; mime_type:string; file_size:int}
type Voice = {file_di:int; durtion:int; mime_type:string; file_size:int}
type Contact = {phone_number:string; first_name:string; last_name:string; user_id:int}

type Message = {id:int; from:User; date:int; chat:Chat; forward_from:User; forward_date:int;
                reply_to_message:Message; text:string; audio:Audio; document:Document; photo:PhotoSize list;
                sticker:Sticker; video:Video; voice:Voice; caption:string; contact:Contact; location:Location;
                new_chat_participant:User; left_chat_participant:User; new_chat_title:string;
                new_chat_photo:PhotoSize list; delete_chat_photo:bool; group_chat_created:bool;
                super_groupchat_created:bool; channel_chat_created:bool; migrate_to_chat_id:bool;
                migrate_from_chat_id:bool}

type Update = {id:int; message:Message; inline_query:InlineQuery; chosen_inline_result:ChosenInlineResult}


let address = "https://api.telegram.org/bot"
let token = "188654328:AAEUweZorPX1FjIKwX3xjlwcXICGB40hksQ"
let useMethod = "getUpdates"
let sep = "/"
let client = new WebClient();
let data = client.DownloadString(address + token + sep + useMethod)

let json = JsonValue.Parse(data)
let res = (json?ok.AsString()) 

