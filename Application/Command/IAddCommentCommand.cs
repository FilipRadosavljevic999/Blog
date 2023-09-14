﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public interface IAddCommentCommand:ICommand<CommentDto>
    {
    }
}
