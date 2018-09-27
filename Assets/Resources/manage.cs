using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage : MonoBehaviour {

    private bool keyLock;

	// Use this for initialization
	void Start () {
        keyLock = false;
        //Photon Realtimeのサーバーへ接続、ロビーへ入室
        PhotonNetwork.ConnectUsingSettings(null);
	}
	

    //ロビーに入室
    void OnJoinedLobby() {
        //とりあえずどこかのロビーへ入室する
        PhotonNetwork.JoinRandomRoom();
    }

    //ルームへ入室した
    void OnJoinedRoom() {
        //入室が完了したことを出力し、キーロック解除
        Debug.Log("ルームへ入室しました。");
        keyLock = true;
    }

    //ルームの入室に失敗
    void OnPhotonRandomJoinFailed() {
        //自分でルームを作成して入室
        PhotonNetwork.CreateRoom(null);
    }

    void FixedUpdate() {
        Debug.Log(keyLock);
        //左クリックを押されたらオブジェクト読み込み
        if (Input.GetMouseButtonDown(0) && keyLock) {
            Debug.Log("push1");
            GameObject mySyncObj = PhotonNetwork.Instantiate("Cube", new Vector3(9.0f, 0f, 0f), Quaternion.identity, 0);
            //動きを付けるためにRigidbodyを取得し、力を加える
            Rigidbody mySyncObjRB = mySyncObj.GetComponent<Rigidbody>();
            mySyncObjRB.isKinematic = false;
            float rndPow = Random.Range(1.0f, 5.0f);
            mySyncObjRB.AddForce(Vector3.left * rndPow, ForceMode.Impulse);
        }
        //左クリックを押されたらオブジェクト読み込み
        if (Input.GetMouseButtonDown(0) && keyLock) {
            Debug.Log("push2");
        }
    }

}
