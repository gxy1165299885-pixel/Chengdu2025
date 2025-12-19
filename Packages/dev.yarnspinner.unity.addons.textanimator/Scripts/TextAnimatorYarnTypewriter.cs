/*
Text Animator for Yarn Spinner is licensed to you under the terms found in the file LICENSE.md.
*/

#if YS_USE_TEXT_ANIMATOR_2 || YS_USE_TEXT_ANIMATOR_3
#define USE_TEXT_ANIMATOR
#endif

#nullable enable

namespace Yarn.Unity.Addons.TextAnimatorIntegration
{
    using System.Threading;
    using System.Collections.Generic;
    using UnityEngine;
    using Yarn.Unity;
    using Yarn.Markup;
#if UNITY_EDITOR
    using UnityEditor;
    using Yarn.Unity.Editor;
#endif
#if !USE_TEXT_ANIMATOR
    using TextAnimator_TMP = UnityEngine.Object;
    using TypewriterCore = UnityEngine.Object;
#endif

    internal enum TagMode
    {
        YarnOnlyTags, TextAnimatorOnlyTags, DefaultYarnMarkup,
    }

#if !USE_TEXT_ANIMATOR
    // This only exists if Text Animator isn't installed
    // in which case it doesn't really do anything except make sure the serialised references aren't lost
    // this means it also has the references for both versions of Text Animator
    public class TextAnimatorYarnTypewriter : MonoBehaviour, IAsyncTypewriter, IAttributeMarkerProcessor
    {

#pragma warning disable CS8618
        [HideInInspector] public List<IActionMarkupHandler> ActionMarkupHandlers { get; set; }
#pragma warning restore CS8618

        public TextAnimator_TMP? Animator;

        public TypewriterCore? Typewriter;

        [SerializeField] internal TagMode tagMode = TagMode.DefaultYarnMarkup;

        public ActionMarkupAction? insertionAction;

#pragma warning disable CS8618
        [SerializeField] private List<string> actionTags;
#pragma warning restore CS8618
        public bool ActionMarkupFinishedProcessing => false;

        public YarnTask RunTypewriter(MarkupParseResult line, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void PrepareForContent(MarkupParseResult line)
        {
            throw new System.NotImplementedException();
        }

        public void ContentWillDismiss()
        {
            throw new System.NotImplementedException();
        }

        public ReplacementMarkerResult ProcessReplacementMarker(MarkupAttribute marker, System.Text.StringBuilder childBuilder, List<MarkupAttribute> childAttributes, string localeCode)
        {
            throw new System.NotImplementedException();
        }
        public void CancelMarkupProcessing()
        {
            throw new System.NotImplementedException();
        }
        public void StartMarkup(int index)
        {
            throw new System.NotImplementedException();
        }
    }
#endif

#if UNITY_EDITOR && YS_USE_TEXT_ANIMATOR_2
    [CustomEditor(typeof(TextAnimatorYarnTypewriter))]
    public class TextAnimatorTypewriterEditor : YarnEditor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var value = target as TextAnimatorYarnTypewriter;
            if (value == null)
            {
                return;
            }

            if (value.insertionAction == null)
            {
                if (value.tagMode != TagMode.TextAnimatorOnlyTags)
                {
                    EditorGUILayout.HelpBox($"The tag mode is set to be {value.tagMode}, but {nameof(value.insertionAction)} is null. You must have an action configured to use this tag mode.", MessageType.Warning);
                }
                return;
            }

            var tagID = value.insertionAction.TagID ?? "NULL";
            var registrationStatus = Editor.TextAnimationActionState.IsActionRegistered(value.insertionAction);

            switch (registrationStatus)
            {
                case Editor.TextAnimationActionState.RegistrationResult.ExistingRegistration:
                    if (value.tagMode != TagMode.TextAnimatorOnlyTags)
                    {
                        EditorGUILayout.HelpBox($"There already exists a Text Animator action registered with tag id: \"{tagID}\". You must only have a single action registered for this tag.", MessageType.Warning);
                    }
                    break;

                case Editor.TextAnimationActionState.RegistrationResult.NotRegistered:
                    if (value.tagMode == TagMode.TextAnimatorOnlyTags)
                    {
                        break;
                    }
                    EditorGUILayout.HelpBox($"The tag mode is set to be {value.tagMode}, but {nameof(value.insertionAction)} is not registered with Text Animator. You must register the action to use this mode.", MessageType.Info);
                    if (GUILayout.Button("Register action"))
                    {
                        Editor.TextAnimationActionState.RegisterAction(value.insertionAction);
                    }
                    break;

                case Editor.TextAnimationActionState.RegistrationResult.Registered:
                    if (value.tagMode == TagMode.TextAnimatorOnlyTags)
                    {
                        EditorGUILayout.HelpBox($"You have registered a Yarn Spinner action tag with Text Animator. This won't cause issues but is indicative of a configuration issue.", MessageType.Info);
                    }
                    break;
            }
        }
    }
#elif UNITY_EDITOR && !YS_USE_TEXT_ANIMATOR_3
    [CustomEditor(typeof(TextAnimatorYarnTypewriter))]
    public class TextAnimatorTypewriterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox($"This package requires configuration before it can be used.", MessageType.Error);
            if (GUILayout.Button("Open Configuration Window"))
            {
                Editor.TextAnimatorConfigurationWindow.OpenWindow();
            }
        }
    }
#endif
}