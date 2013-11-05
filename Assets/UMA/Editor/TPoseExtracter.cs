﻿using UnityEngine;
using UnityEditor;

public static class TPoseExtracter  {

    [MenuItem("UMA/Extract T-Pose")]
    static void ExtractTPose()
    {
        foreach (var animator in Transform.FindObjectsOfType(typeof(Animator)) as Animator[])
        {
            var asset = UmaTPose.CreateInstance<UmaTPose>();
            asset.ReadFromTransform(animator);
            var name = animator.name;
            if (name.EndsWith("(Clone)"))
            {
                name = name.Substring(0, name.Length - 7);
            }
            if (!System.IO.Directory.Exists("Assets/UMA/Assets/TPoses"))
                System.IO.Directory.CreateDirectory("Assets/UMA/UMA_Assets/TPoses");
            AssetDatabase.CreateAsset(asset, "Assets/UMA/UMA_Assets/TPoses/" + name + "_TPose.asset");
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }
    }


//    [UnityEditor.MenuItem("UMA/Extract T-Pose")]
//    static void ExtractTPose()
//    {
//        foreach (var animator in Transform.FindObjectsOfType<Animator>())
//        {
//            var asset = UmaTPose.CreateInstance<UmaTPose>();
//            asset.ReadFromTransform(animator);
//            var name = animator.name;
//            if (name.EndsWith("(Clone)"))
//            {
//                name = name.Substring(0, name.Length - 7);
//            }
//            if (!System.IO.Directory.Exists("Assets/UMA/Assets/TPoses"))
//                System.IO.Directory.CreateDirectory("Assets/UMA/UMA_Assets/TPoses");
//            UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/UMA/UMA_Assets/TPoses/" + name + "_TPose.asset");
//            UnityEditor.EditorUtility.SetDirty(asset);
//            UnityEditor.AssetDatabase.SaveAssets();
//        }
//    }

//    [UnityEditor.MenuItem("Tools/Dump Selected Skeleton")]
//    public static void DumpSelectedSkeleton()
//    {
//        foreach (var hierarchy in UnityEditor.Selection.transforms)
//        {
//            Debug.Log("Dumping Skeleton for " + hierarchy.name, hierarchy);
//            var sb = new StringBuilder();
//            DumpSkeleton(hierarchy, sb);

//            sb.AppendLine();
//            int i = 0;
//            foreach (var bone in HumanTrait.BoneName)
//            {
//                sb.AppendFormat("// {0} {1}", bone, HumanTrait.RequiredBone(i) ? "Required" : "");
//                sb.AppendLine();
//                i++;
//            }

//            System.IO.File.WriteAllText(hierarchy.name + "_stuff.cs", sb.ToString());
//        }
//    }

//    private static void DumpSkeleton(Transform hierarchy, StringBuilder sb)
//    {
//        sb.AppendFormat(@"boneList.Add(new SkeletonBone()
//                         {{
//                             name = ""{0}"",
//                             position = new Vector3({1}f,{2}f,{3}f),
//                             rotation = new Quaternion({4}f,{5}f,{6}f,{7}f),
//                             scale = new Vector3({8}f,{9}f,{10}f),
//                             transformModified = 0
//                         }});", hierarchy.name, hierarchy.localPosition.x, hierarchy.localPosition.y, hierarchy.localPosition.z, hierarchy.localRotation.x, hierarchy.localRotation.y, hierarchy.localRotation.z, hierarchy.localRotation.w, hierarchy.localScale.x, hierarchy.localScale.y, hierarchy.localScale.z);
//        sb.AppendLine();
//        //            boneList.Add(new SkeletonBone()
//        //                 {
//        //                     name = "bone",
//        //                     position = new Vector3(0,1,2),
//        //                     rotation = new Quaternion(0,1,2,3),
//        //                     scale = new Vector3(1,1,1),
//        //                     transformModified = 0
//        //                 });
//        //humanList.Add(new HumanBone() { boneName = "bone", humanName = "Hips", limit = new HumanLimit() {useDefaultValues = true}});

//        for (int i = 0; i < hierarchy.childCount; i++)
//        {
//            var child = hierarchy.GetChild(i);
//            DumpSkeleton(child, sb);
//        }
//    }

}