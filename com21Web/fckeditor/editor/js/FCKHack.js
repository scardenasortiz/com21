// Some Class
function MyFCKClass()
{
        this.UpdateEditorFormValue = function()
        {
                for ( i = 0; i < parent.frames.length; ++i )
                        if ( parent.frames[i].FCK )
                                parent.frames[i].FCK.UpdateLinkedField();
        }
}
// instantiate the class
var MyFCKObject = new MyFCKClass();