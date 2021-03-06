﻿using SimpleMVC.App.MVC.Interfaces.Generic;
using System;

namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action =
                (IRenderable<T>)Activator
                .CreateInstance(Type.GetType(viewFullQualifiedName));

            Action.Model = model;
        }

        public ActionResult(string viewFullQualifiedName, T model, string location) : this(viewFullQualifiedName, model)
        {
            this.Location = location;
        }
        public IRenderable<T> Action { get; set; }

        public string Location { get; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}