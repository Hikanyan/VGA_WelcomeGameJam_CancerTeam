using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectCollision : MonoBehaviour
{
    [Header("����𓥂񂾎��̃v���C���[�����˂鍂��")] public float boundHeight;
    [Header("����𓥂񂾎��̃v���C���[�����˂鑬��")] public float jumpSpeed;
    /// <summary>
    /// ���̃I�u�W�F�N�g���v���C���[�����񂾂��ǂ���
    /// </summary>
    [HideInInspector] public bool playerStepOn;
}