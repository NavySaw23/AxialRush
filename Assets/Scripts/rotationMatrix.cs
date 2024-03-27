using System;
using UnityEngine;

public class Rmatrix
{
    public Rmatrix Lturn;
    public Rmatrix Rturn;
    public Rmatrix Lroll;
    public Rmatrix Rroll;   
    public string name;
    public Quaternion DirQuat;

    public Rmatrix()
    {
        DirQuat = Quaternion.identity;
        name = "Unassigned";
    }

    public Rmatrix(string _name, float _w, float _x, float _y, float _z)
    {
        DirQuat = new Quaternion((float)_x, (float)_y, (float)_z, (float)_w);
        name = _name;
    }
}
public class rotationMatrix : MonoBehaviour
{
    public Rmatrix RW = new Rmatrix("RedWhite", 1, 0, 0, 0); 
    //RW means R Front W Top            // initialized as w,x,y,z
    public Rmatrix RB = new Rmatrix("RedBlue", 0.707107f, 0, 0, 0.707107f);
    public Rmatrix RG = new Rmatrix("RedGreen", -0.707107f, 0, 0, 0.707107f);
    public Rmatrix RY = new Rmatrix("RedYellow", 0, 0, 0, 1);

    public Rmatrix BW = new Rmatrix("BlueWhite", 0.7071068f, 0, 0.7071068f, 0);
    public Rmatrix BR = new Rmatrix("BlueRed", 0.5f, 0.5f, 0.5f, -0.5f);
    public Rmatrix BO = new Rmatrix("BlueOrange", 0.5f, -0.5f, 0.5f, 0.5f);
    public Rmatrix BY = new Rmatrix("BlueYellow", 0,  0.7071068f, 0, - 0.7071068f);


    public Rmatrix OW = new Rmatrix("OrangeWhite", 0, 0, 1f, 0);
    public Rmatrix OB = new Rmatrix("OrangeBlue", 0, -0.7071068f, -0.7071068f, 0);
    public Rmatrix OG = new Rmatrix("OrangeGreen", 0, 0.7071068f, -0.7071068f, 0);
    public Rmatrix OY = new Rmatrix("OrangeYellow", 0, -1, 0, 0);

    public Rmatrix GW = new Rmatrix("GreenWhite", 0.707107f, 0, -0.707107f, 0);
    public Rmatrix GO = new Rmatrix("GreenOrange", 0.5f, -0.5f, -0.5f, -0.5f);
    public Rmatrix GR = new Rmatrix("GreenRed", 0.5f, 0.5f, -0.5f, 0.5f);
    public Rmatrix GY = new Rmatrix("GreenYellow", 0, -0.707107f, 0, -0.707107f);

    public Rmatrix YR = new Rmatrix("YellowRed", 0.7071068f, 0.7071068f, 0, 0);
    public Rmatrix YB = new Rmatrix("YellowBlue", 0.5f, 0.5f, 0.5f, 0.5f);
    public Rmatrix YG = new Rmatrix("YellowGreen", 0.5f, 0.5f, -0.5f, -0.5f);
    public Rmatrix YO = new Rmatrix("YellowOrange", 0, 0, -0.7071068f, -0.7071068f);

    public Rmatrix WR = new Rmatrix("WhiteRed", 0, 0, 0.7071068f, -0.7071068f);
    public Rmatrix WB = new Rmatrix("WhiteBlue", 0.5f, -0.5f, -0.5f, 0.5f);
    public Rmatrix WG = new Rmatrix("WhiteGreen", 0.5f, -0.5f, 0.5f, -0.5f);
    public Rmatrix WO = new Rmatrix("WhiteOrange", 0.7071068f, -0.7071068f, 0, 0);

    public Rmatrix Current;

    rotationMatrix()
    {
        Current = RW;

        // RED ------------------------------------------------------------------------------
        //Face Red, Top White
        RW.Lturn = BW;
        RW.Rturn = GW;
        RW.Lroll = RG;
        RW.Rroll = RB;
        //Face Red, Top Yellow
        RY.Lturn = GY;
        RY.Rturn = BY;
        RY.Lroll = RB;
        RY.Rroll = RG;
        //Face Red, Top Blue
        RB.Lturn = YB;
        RB.Rturn = WB;
        RB.Lroll = RW;
        RB.Rroll = RY;
        //Face Red, Top Green
        RG.Lturn = WG;
        RG.Rturn = YG;
        RG.Lroll = RY;
        RG.Rroll = RW;

        // BLUE ------------------------------------------------------------------------------
        //Face Blue, Top White
        BW.Lturn = OW;
        BW.Rturn = RW;
        BW.Lroll = BR;
        BW.Rroll = BO;
        //Face Blue, Top Yellow
        BY.Lturn = RY;
        BY.Rturn = OY;
        BY.Lroll = BO;
        BY.Rroll = BR;
        //Face Blue, Top Red
        BR.Lturn = WR;
        BR.Rturn = YR;
        BR.Lroll = BY;
        BR.Rroll = BW;
        //Face Blue, Top Orange
        BO.Lturn = YO;
        BO.Rturn = WO;
        BO.Lroll = BW;
        BO.Rroll = BY;


        // ORANGE ------------------------------------------------------------------------------
        //Face Orange, Top White
        OW.Lturn = GW;
        OW.Rturn = BW;
        OW.Lroll = OB;
        OW.Rroll = OG;
        //Face Orange, Top Yellow 
        OY.Lturn = BY;
        OY.Rturn = GY;
        OY.Lroll = OG;
        OY.Rroll = OB;
        //Face Orange, Top Green
        OG.Lturn = YG;
        OG.Rturn = WG;
        OG.Lroll = OW;
        OG.Rroll = OY;
        //Face Orange, Top Blue
        OB.Lturn = WB;
        OB.Rturn = YB;
        OB.Lroll = OY;
        OB.Rroll = OW;


        // Green ------------------------------------------------------------------------------
        //Face Green, Top White
        GW.Lturn = RW;
        GW.Rturn = OW;
        GW.Lroll = GO;
        GW.Rroll = GR;
        //Face Green, Top Yellow
        GY.Lturn = OY;
        GY.Rturn = RY;
        GY.Lroll = GR;
        GY.Rroll = GO;
        //Face Green, Top Red
        GR.Lturn = YR;
        GR.Rturn = WR;
        GR.Lroll = GW;
        GR.Rroll = GY;
        //Face Green, Top Orange
        GO.Lturn = WO;
        GO.Rturn = YO;
        GO.Lroll = GY;
        GO.Rroll = GW;

        // WHITE ------------------------------------------------------------------------------
        //Face White, Top Orange
        WO.Lturn = BO;
        WO.Rturn = GO;
        WO.Lroll = WG;
        WO.Rroll = WB;
        //Face White, Top Red
        WR.Lturn = GR;
        WR.Rturn = BR;
        WR.Lroll = WB;
        WR.Rroll = WG;
        //Face White, Top Blue
        WB.Lturn = RB;
        WB.Rturn = OB;
        WB.Lroll = WO;
        WB.Rroll = WR;
        //Face White, Top Green
        WG.Lturn = OG;
        WG.Rturn = RG;
        WG.Lroll = WR;
        WG.Rroll = WO;

        // YELLOW ------------------------------------------------------------------------------
        //Face Yellow, Top Orange
        YO.Lturn = GO;
        YO.Rturn = BO;
        YO.Lroll = YB;
        YO.Rroll = YG;
        //Face Yellow, Top Red
        YR.Lturn = BR;
        YR.Rturn = GR;
        YR.Lroll = YG;
        YR.Rroll = YB;
        //Face Yellow, Top Blue
        YB.Lturn = OB;
        YB.Rturn = RB;
        YB.Lroll = YR;
        YB.Rroll = YO;
        //Face Yellow, Top Green
        YG.Lturn = RG;
        YG.Rturn = OG;
        YG.Lroll = YO;
        YG.Rroll = YR;
    }

}

