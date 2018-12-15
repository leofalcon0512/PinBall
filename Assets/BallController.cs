using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	private int score;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.scoreText = GameObject.Find ("Score");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
	



	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag == "SmallStar Tag"){
			score += 10;
		}else if(other.gameObject.tag == "LargeStar Tag"){
			score += 20;
		}else if(other.gameObject.tag == "SmallCloud Tag"){
			score -= 10;
		}else if(other.gameObject.tag == "LargeCloud Tag"){
			score -= 20;
		}

		this.scoreText.GetComponent<Text> ().text = score + "点";
	}
}