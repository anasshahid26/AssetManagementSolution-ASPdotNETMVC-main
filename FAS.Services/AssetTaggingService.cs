using System.Collections.Generic;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Data;
using System.Web;

namespace FAS.Services
{
    public class AssetTaggingAdapter : IAssetTagService
    {
        AssetTaggingAdapter assetTaggingAdapter;


        public AssetTaggingAdapter()
        {
            assetTaggingAdapter = new AssetTaggingAdapter();
           
        }


       

        public string AssetTagging(AssetAdditionViewModel assetAddition)
        {
            return assetTaggingAdapter.AssetTagging(assetAddition);
        }

    
    }

    public interface IAssetTagService
    {
  

        string AssetTagging(AssetAdditionViewModel assetAddition);

     
    }
}
