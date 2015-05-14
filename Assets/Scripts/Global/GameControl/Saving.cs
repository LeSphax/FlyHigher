using System.Collections;
using System.IO;

public interface Saving{

	void Save(FileStream file, GameData.PlayerData data);
	
	GameData.PlayerData Load(FileStream file);
}
