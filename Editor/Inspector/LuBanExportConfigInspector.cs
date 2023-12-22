using UnityEditor;
using UnityEngine;

namespace Luban.Editor
{
    [CustomEditor(typeof(LubanExportConfig))]
    public class LuBanExportConfigInspector : UnityEditor.Editor
    {
        private SerializedProperty m_output_data_dir;
        private SerializedProperty m_tpl_path;
        private SerializedProperty m_which_dll;
        private SerializedProperty m_output_code_dir;
        private SerializedProperty m_output_data_resources_list_file;
        private SerializedProperty m_output_exclude_tags;
        private SerializedProperty m_output_data_file_extension;
        private SerializedProperty m_output_data_compact_json;
        private SerializedProperty m_output_data_json_monolithic_file;
        private SerializedProperty m_preview_command;

        private SerializedProperty m_job;

        // private SerializedProperty m_define_xml;
        private SerializedProperty m_codeTarget;
        private SerializedProperty m_dataTarget;
        private SerializedProperty m_service;
        private SerializedProperty m_i10n_timezone;
        private SerializedProperty m_i10n_input_text_files;
        private SerializedProperty m_i10n_text_field_name;
        private SerializedProperty m_i10n_output_not_translated_text_file;
        private SerializedProperty m_i10n_path;
        private SerializedProperty m_i10n_patch_input_data_dir;

        private void OnEnable()
        {
            m_which_dll = serializedObject.FindProperty("which_dll");
            m_tpl_path = serializedObject.FindProperty("tpl_path");
            m_job = serializedObject.FindProperty("job");
            m_codeTarget = serializedObject.FindProperty("codeTarget");
            m_dataTarget = serializedObject.FindProperty("dataTarget");
            m_service = serializedObject.FindProperty("service");

            m_output_data_dir = serializedObject.FindProperty("output_data_dir");
            m_output_code_dir = serializedObject.FindProperty("output_code_dir");
            m_output_data_resources_list_file = serializedObject.FindProperty("output_data_resources_list_file");
            m_output_exclude_tags = serializedObject.FindProperty("output_exclude_tags");
            m_output_data_file_extension = serializedObject.FindProperty("output_data_file_extension");
            m_output_data_compact_json = serializedObject.FindProperty("output_data_compact_json");
            m_output_data_json_monolithic_file = serializedObject.FindProperty("output_data_json_monolithic_file");

            m_i10n_timezone = serializedObject.FindProperty("i10n_timezone");
            m_i10n_input_text_files = serializedObject.FindProperty("i10n_input_text_files");
            m_i10n_text_field_name = serializedObject.FindProperty("i10n_text_field_name");
            m_i10n_output_not_translated_text_file = serializedObject.FindProperty("i10n_output_not_translated_text_file");
            m_i10n_path = serializedObject.FindProperty("i10n_path");
            m_i10n_patch_input_data_dir = serializedObject.FindProperty("i10n_patch_input_data_dir");


            m_preview_command = serializedObject.FindProperty("preview_command");
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var config = (LubanExportConfig)target;

            EditorGUILayout.PropertyField(m_which_dll, new GUIContent("Client&Server Dll"));
            EditorGUILayout.PropertyField(m_tpl_path, new GUIContent("模板路径"));
            EditorGUILayout.PropertyField(m_job, new GUIContent("任务"));
            // EditorGUILayout.PropertyField(m_define_xml, new GUIContent("定义XML"));
            EditorGUILayout.PropertyField(m_codeTarget, new GUIContent("生成类型"));
            EditorGUILayout.PropertyField(m_dataTarget, new GUIContent("生成类型"));
            EditorGUILayout.PropertyField(m_service, new GUIContent("服务类型"));

            EditorGUILayout.PropertyField(m_output_data_dir, new GUIContent("输出数据文件夹"));
            EditorGUILayout.PropertyField(m_output_code_dir, new GUIContent("输出代码文件夹"));
            EditorGUILayout.PropertyField(m_output_data_resources_list_file, new GUIContent("输出数据资源列表文件"));
            EditorGUILayout.PropertyField(m_output_exclude_tags, new GUIContent("输出排除标签"));
            EditorGUILayout.PropertyField(m_output_data_file_extension, new GUIContent("输出数据文件扩展名"));
            EditorGUILayout.PropertyField(m_output_data_compact_json, new GUIContent("输出数据压缩JSON"));
            EditorGUILayout.PropertyField(m_output_data_json_monolithic_file, new GUIContent("输出数据JSON独立文件"));


            EditorGUILayout.PropertyField(m_i10n_timezone, new GUIContent("多语言时区"));
            EditorGUILayout.PropertyField(m_i10n_input_text_files, new GUIContent("多语言文本文件"));
            EditorGUILayout.PropertyField(m_i10n_text_field_name, new GUIContent("多语言文本字段名"));
            EditorGUILayout.PropertyField(m_i10n_output_not_translated_text_file, new GUIContent("未翻译文本存放位置"));
            EditorGUILayout.PropertyField(m_i10n_path, new GUIContent("多语言文件夹"));
            EditorGUILayout.PropertyField(m_i10n_patch_input_data_dir, new GUIContent("多语言补丁文件夹"));

            EditorGUILayout.PropertyField(m_preview_command, new GUIContent("预览命令"));

            if (GUILayout.Button("生成"))
            {
                config.Gen();
            }

            if (GUILayout.Button("预览命令"))
            {
                config.Preview();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}